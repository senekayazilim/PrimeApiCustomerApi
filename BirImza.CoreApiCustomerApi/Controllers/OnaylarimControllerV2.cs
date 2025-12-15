using BirImza.Types;
using BirImza.Types.Shared;
using Flurl.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml;
using static System.Net.WebRequestMethods;

namespace BirImza.CoreApiCustomerApi.Controllers
{
    public partial class OnaylarimController : ControllerBase
    {
        private int chunkSize = 8 * 1024 * 1024; // 8MB

        [RequestSizeLimit(200L * 1024 * 1024)]           // 200 MB
        [RequestFormLimits(MultipartBodyLengthLimit = 200L * 1024 * 1024)]
        [HttpPost("UploadFileV2")]
        public async Task<ProxyUploadFileResultV2> UploadFileV2([FromForm] IFormFile file)
        {
            var result = new ProxyUploadFileResultV2();

            if (file == null || file.Length == 0)
            {
                result.Error = "Yüklenecek dosya bulunamadı.";
                return result;
            }

            var form = await Request.ReadFormAsync();
            string? filename = form["fileName"];          // encodeURIComponent ile dolduruldu


            if (string.IsNullOrWhiteSpace(filename))
            {
                result.Error = "Filename is required.";
                return result;
            }

            var operationId = Guid.NewGuid();
            result.OperationId = operationId;

            try
            {
                using var stream = file.OpenReadStream();

                if (stream.Length >= chunkSize)
                {
                    byte[] fileData = new byte[stream.Length];
                    stream.ReadExactly(fileData, 0, (int)stream.Length);
                    await ChunkUploadFileHelper(fileData, result);
                    return result;
                }

                var uploadFileV2Result = await $"{_onaylarimServiceUrl}/V2/CoreApiFile/UploadFile"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostMultipartAsync(mp => mp
                                            .AddFile("file", stream, file.FileName, string.IsNullOrWhiteSpace(file.ContentType) ? "application/octet-stream" : file.ContentType)
                                    )
                                    .ReceiveJson<ApiResult<UploadFileV2Result>>();

                if (!string.IsNullOrWhiteSpace(uploadFileV2Result.Error))
                {
                    result.Error = uploadFileV2Result.Error;
                    return result;
                }

                if (uploadFileV2Result.Result != null)
                {
                    result.IsSuccess = uploadFileV2Result.Result.IsSuccess;
                    result.OperationId = uploadFileV2Result.Result.OperationId;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UploadFile");
                result.Error = ex.Message;
            }

            return result;
        }

        [HttpPost("ChunkUploadFileV2")]
        public async Task<ProxyUploadFileResultV2> ChunkUploadFileV2([FromForm] IFormFile file)
        {

            var result = new ProxyUploadFileResultV2();

            if (file == null || file.Length == 0)
            {
                result.Error = "Yüklenecek dosya bulunamadı.";
                return result;
            }

            var operationId = Guid.NewGuid();
            result.OperationId = operationId;



            try
            {
                using var stream = file.OpenReadStream();

                if (stream.Length <= chunkSize)
                {

                }

                byte[] fileData = new byte[stream.Length];
                stream.ReadExactly(fileData, 0, (int)stream.Length);

                await ChunkUploadFileHelper(fileData, result);

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UploadFile");
                result.Error = ex.Message;
            }


            return result;

        }


        private async Task<ProxyUploadFileResultV2> ChunkUploadFileHelper(byte[] fileData, ProxyUploadFileResultV2 result)
        {

            var chunkSize = 8 * 1024 * 1024; // 8MB

            try
            {

                Guid? uploadSessionId = null;
                // 1) ChunkInit
                var totalChunks = (int)Math.Ceiling((double)fileData.Length / chunkSize);
                var initializeChunkedUploadResult = await $"{_onaylarimServiceUrl}/V2/CoreApiFile/ChunkInit"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(new InitializeChunkedUploadRequest
                                    {
                                        OperationId = result.OperationId,
                                        ChunkSize = chunkSize,
                                        TotalSize = fileData.LongLength,
                                        TotalChunks = totalChunks,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en"
                                    })
                                    .ReceiveJson<ApiResult<InitializeChunkedUploadResult>>();

                if (!string.IsNullOrWhiteSpace(initializeChunkedUploadResult.Error))
                {
                    result.Error = initializeChunkedUploadResult.Error;
                    return result;
                }

                uploadSessionId = initializeChunkedUploadResult.Result.UploadSessionId;

                try
                {
                    // 2) ChunkUpload (0-tabanlı)
                    for (var chunkIndex = 0; chunkIndex < totalChunks; chunkIndex++)
                    {
                        var offset = chunkIndex * chunkSize;
                        var length = Math.Min(chunkSize, fileData.Length - offset);
                        var buffer = new byte[length];
                        Buffer.BlockCopy(fileData, offset, buffer, 0, length);

                        var content = new ByteArrayContent(buffer);
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        var uploadChunkResult = await $"{_onaylarimServiceUrl}/v2/CoreApiFile/ChunkUpload"
                                                        .WithHeader("X-API-KEY", _apiKey)
                                                        .WithHeader("uploadsessionid", uploadSessionId)
                                                        .WithHeader("chunkindex", chunkIndex)
                                                        .PostAsync(content)
                                                        .ReceiveJson<ApiResult<UploadChunkResult>>();

                        if (!string.IsNullOrWhiteSpace(uploadChunkResult.Error) || (uploadChunkResult.Result != null && uploadChunkResult.Result.Accepted == false))
                        {
                            await $"{_onaylarimServiceUrl}/v2/CoreApiFile/ChunkAbort"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(new AbortChunkedUploadRequest
                                    {
                                        UploadSessionId = uploadSessionId.Value,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en"
                                    });
                            result.Error = string.IsNullOrWhiteSpace(uploadChunkResult.Error) ? $"ChunkUpload not accepted at index {chunkIndex}" : uploadChunkResult.Error;
                            return result;
                        }
                    }

                    // 3) ChunkComplete
                    var completeResult = await $"{_onaylarimServiceUrl}/v2/CoreApiFile/ChunkComplete"
                                            .WithHeader("X-API-KEY", _apiKey)
                                            .PostJsonAsync(new CompleteChunkedUploadRequest
                                            {
                                                UploadSessionId = uploadSessionId.Value,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en"
                                            })
                                            .ReceiveJson<ApiResult<CompleteChunkedUploadResult>>();

                    if (!string.IsNullOrWhiteSpace(completeResult.Error) || completeResult.Result.IsSuccess == false)
                    {
                        result.Error = string.IsNullOrWhiteSpace(completeResult.Error) ? "ChunkComplete failed" : completeResult.Error;
                        return result;
                    }
                    else
                    {
                        result.IsSuccess = true;
                        result.OperationId = completeResult.Result.OperationId;
                        return result;
                    }
                }
                catch (Exception)
                {
                    if (uploadSessionId.HasValue)
                    {
                        try
                        {
                            await $"{_onaylarimServiceUrl}/v2/CoreApiFile/ChunkAbort"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(new AbortChunkedUploadRequest
                                    {
                                        UploadSessionId = uploadSessionId.Value,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en"
                                    });
                        }
                        catch { }
                    }
                    throw;
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UploadFile");
                result.Error = ex.Message;
            }


            return result;

        }

        /// <summary>
        /// Dosyayı indirmek için kullanılır
        /// </summary>
        /// <param name="operationId"></param>
        /// <returns></returns>
        [HttpGet("DownloadCoreV2")]
        public async Task<IActionResult> DownloadCoreV2(Guid operationId)
        {

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var downloadSignedFileCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiFile/DownloadCore"
                                        .WithHeader("X-API-KEY", _apiKey)
                                        .PostJsonAsync(
                                            new DownloadSignedFileCoreRequestV2()
                                            {
                                                OperationId = operationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                            })
                                        .ReceiveJson<ApiResult<DownloadSignedFileCoreResult>>();

                Response.Headers.Append("Access-Control-Expose-Headers", "Content-Disposition");

                return File(downloadSignedFileCoreResult.Result.FileData, "application/octet-stream", downloadSignedFileCoreResult.Result.FileName);

            }
            catch (Exception ex)
            {
            }
            return BadRequest("Hata");
        }

        /// <summary>
        /// PDF dosyasının üzerine doğrulama cümlesi ve karekod basar
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddLayersV2")]
        public async Task<IActionResult> AddLayersV2(ProxyAddVerificationInfoCoreRequest request)
        {

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var addLayersCoreResultV2 = await $"{_onaylarimServiceUrl}/v2/CoreApiPdf/AddLayersCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new AddLayersCoreRequestV2()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            VerificationInfo = new VerificationInfo()
                                            {
                                                Bottom = request.VerificationInfo.Bottom,
                                                Height = request.VerificationInfo.Height,
                                                Left = request.VerificationInfo.Left,
                                                Right = request.VerificationInfo.Right,
                                                Text = request.VerificationInfo.Text,
                                                Top = request.VerificationInfo.Top,
                                                TransformOrigin = request.VerificationInfo.TransformOrigin,
                                                Width = request.VerificationInfo.Width,
                                            },
                                            QrCodeInfo = new QrCodeInfo()
                                            {
                                                Bottom = request.QrCodeInfo.Bottom,
                                                Left = request.QrCodeInfo.Left,
                                                Right = request.QrCodeInfo.Right,
                                                Text = request.QrCodeInfo.Text,
                                                Top = request.QrCodeInfo.Top,
                                                TransformOrigin = request.QrCodeInfo.TransformOrigin,
                                                Width = request.QrCodeInfo.Width,
                                            }
                                        })
                                .ReceiveJson<ApiResult<AddLayersCoreResultV2>>();

                if (string.IsNullOrWhiteSpace(addLayersCoreResultV2.Error))
                {
                    return Ok();
                }
                return Problem(
                   detail: addLayersCoreResultV2.Error,
                   title: "Hata",
                   statusCode: 400
                 );

            }
            catch (Exception ex)
            {
                return Problem(
                   detail: ex.Message,
                   title: "Exception",
                   statusCode: 400
                 );
            }


        }

        #region Mobile Sign

        /// <summary>
        /// Mobil imza atma işlemi için kullanılan metoddur
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("MobileSignV2")]
        public async Task<ProxyMobilSignResult> MobileSignV2(ProxyMobileSignRequestV2 request)
        {
            var result = new ProxyMobilSignResult();

            if (request.SignatureType == "cades")
            {
                // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                //var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiCadesMobile/SignStepOneCadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneCadesMobileCoreRequestV2()
                                            {
                                                //FileData = fileData,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
                                                SignatureLevel = request.SignatureLevelForCades,
                                                SignaturePath = request.SignaturePath,
                                                SignatureTurkishProfile = request.SignatureTurkishProfile,
                                                SerialOrParallel = request.SerialOrParallel

                                            })
                                    .ReceiveJson<ApiResult<SignStepOneCoreInternalForCadesMobileResult>>();

                    if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error) == false)
                    {
                        result.Error = signStepOneCoreResult.Error;
                    }
                    else
                    {
                        result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;
                    }
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                }
            }
            else if (request.SignatureType == "xades")
            {
                // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.xml");

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiXadesMobile/SignStepOneXadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneXadesMobileCoreRequestV2()
                                            {
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
                                                SignatureLevel = request.SignatureLevelForXades,
                                                SignaturePath = request.SignaturePath,
                                                SignatureTurkishProfile = request.SignatureTurkishProfile,
                                                SerialOrParallel = request.SerialOrParallel,
                                                EnvelopingOrEnveloped = request.EnvelopingOrEnveloped
                                            })
                                    .ReceiveJson<ApiResult<SignStepOneCoreInternalForXadesMobileResult>>();

                    if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error) == false)
                    {
                        result.Error = signStepOneCoreResult.Error;
                    }
                    else
                    {
                        result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;
                    }
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                }
            }
            else if (request.SignatureType == "pades")
            {
                // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                //var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

                var myRequest = new SignStepOnePadesMobileCoreRequestV2()
                {
                    OperationId = request.OperationId,
                    RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                    DisplayLanguage = "en",
                    PhoneNumber = request.PhoneNumber,
                    Operator = request.Operator,
                    UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                    CitizenshipNo = request.CitizenshipNo,
                    SignatureLevel = request.SignatureLevelForPades,
                    SignatureTurkishProfile = request.SignatureTurkishProfile,
                };


                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiPadesMobile/SignStepOnePadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(myRequest)
                                    .ReceiveJson<ApiResult<SignStepOneCoreInternalForPadesMobileResult>>();

                    if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error) == false)
                    {
                        result.Error = signStepOneCoreResult.Error;
                    }
                    else
                    {
                        result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;
                    }
                }
                catch (Exception ex)
                {
                    result.Error = ex.Message;
                }
            }
            return result;

        }


        [HttpPost("GetFingerPrintV2")]
        public async Task<ProxyGetFingerPrintResult> GetFingerPrintV2(ProxyGetFingerPrintRequest request)
        {
            var result = new ProxyGetFingerPrintResult();
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getFingerPrintCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiFingerPrint/GetFingerPrintCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetFingerPrintCoreRequestV2()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<GetFingerPrintCoreResult>>();

                result.FingerPrint = getFingerPrintCoreResult.Result.FingerPrint;
            }
            catch (Exception ex)
            {
            }
            return result;

        }
        #endregion

        #region Cades

        /// <summary>
        /// CADES e-imza atma işlemi için ilk adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForCadesV2")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForCadesV2(ProxyCreateStateOnOnaylarimApiForCadesRequestV2 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiV2 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();


            try
            {

                var signatureWidgetBackground = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\Signature01.jpg");

                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepOneCadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiCades/SignStepOneCadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOneCadesCoreRequestV2()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SerialOrParallel = request.SerialOrParallel,
                                        SignaturePath = request.SignaturePath,
                                        SignatureTurkishProfile = request.SignatureTurkishProfile,
                                        CitizenshipNo = request.CitizenshipNo,
                                    })
                            .ReceiveJson<ApiResult<SignStepOneCadesCoreResult>>();


                if (string.IsNullOrWhiteSpace(signStepOneCadesCoreResult.Error))
                {
                    result.KeyID = signStepOneCadesCoreResult.Result.KeyID;
                    result.KeySecret = signStepOneCadesCoreResult.Result.KeySecret;
                    result.State = signStepOneCadesCoreResult.Result.State;
                    result.OperationId = signStepOneCadesCoreResult.Result.OperationId;
                }
                else
                {
                    result.Error = signStepOneCadesCoreResult.Error;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateStateOnOnaylarimApi");
            }
            return result;

        }

        /// <summary>
        /// CADES e-imza atma işlemi için son adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForCadesV2")]
        public async Task<ProxyFinishSignResult> FinishSignForCadesV2(ProxyFinishSignForCadesRequestV2 request)
        {
            _logger.LogInformation("FinishSign");

            var result = new ProxyFinishSignResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepThreeCadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiCades/signStepThreeCadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreeCadesCoreRequestV2
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = request.SignatureLevel,
                                        })
                                .ReceiveJson<ApiResult<SignStepThreeCadesCoreResult>>();

                result.IsSuccess = signStepThreeCadesCoreResult.Result.IsSuccess;
                result.OperationId = signStepThreeCadesCoreResult.Result.OperationId;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSign");
            }

            return result;
        }

        /// <summary>
        /// Cades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListCadesV2")]
        public async Task<ProxyGetSignatureListResult> GetSignatureListCadesV2(Guid operationId)
        {
            var result = new ProxyGetSignatureListResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiCades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreResult>>();

                if (getSignatureListCoreResult.Result.Signatures != null)
                {
                    result.Signatures = getSignatureListCoreResult.Result.Signatures
                        .Select(x => new ProxyGetSignatureListResultItem()
                        {
                            ClaimedSigningTime = x.ClaimedSigningTime,
                            EntityLabel = x.EntityLabel,
                            Level = x.Level,
                            LevelString = x.LevelString,
                            SubjectRDN = x.SubjectRDN,
                            Timestamped = x.Timestamped,
                            CitizenshipNo = x.CitizenshipNo
                        });
                }





            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }

        /// <summary>
        /// Cades imzalı bir belgenin e-imzalarını zenginleştirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("UpgradeCadesV2")]
        public async Task<IActionResult> UpgradeCadesV2(Guid operationId, int signatureLevel, string signaturePath)
        {
            ApiResult<UpgradeCadesCoreResult> upgradeCadesCoreResult = null;
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                upgradeCadesCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiCades/UpgradeCadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradeCadesCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = (SignatureLevelForCades)(signatureLevel),
                                            SignaturePath = signaturePath
                                        })
                                .ReceiveJson<ApiResult<UpgradeCadesCoreResult>>();

                if (string.IsNullOrWhiteSpace(upgradeCadesCoreResult.Error) == false)
                {
                    return BadRequest("İmza zenginleştirilemedi. Hata: " + upgradeCadesCoreResult.Error);
                }
                if (upgradeCadesCoreResult.Result.IsSuccess == false)
                {
                    return BadRequest("İmza zenginleştirilemedi.");
                }

                return Ok(upgradeCadesCoreResult.Result.OperationId);


            }
            catch (Exception ex)
            {
            }

            if (upgradeCadesCoreResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(upgradeCadesCoreResult.Error) == false)
            {
                return BadRequest(upgradeCadesCoreResult.Error);
            }
            else if (upgradeCadesCoreResult.Result.IsSuccess == false)
            {
                return BadRequest("Hata");
            }


            return BadRequest("Hata");

        }

        #endregion

        #region Xades

        /// <summary>
        /// Xades e-imza atma işlemi için ilk adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForXadesV2")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForXadesV2(ProxyCreateStateOnOnaylarimApiForXadesRequestV2 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiV2 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();


            try
            {

                var signatureWidgetBackground = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\Signature01.jpg");

                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepOneXadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiXades/SignStepOneXadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOneXadesCoreRequestV2()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SerialOrParallel = request.SerialOrParallel,
                                        SignaturePath = request.SignaturePath,
                                        SignatureTurkishProfile = request.SignatureTurkishProfile,
                                        CitizenshipNo = request.CitizenshipNo,
                                        EnvelopingOrEnveloped = request.EnvelopingOrEnveloped,
                                        EnvelopingObjectEncoding = request.EnvelopingObjectEncoding,
                                        EnvelopingObjectMimeType = request.EnvelopingObjectMimeType
                                    })
                            .ReceiveJson<ApiResult<SignStepOneXadesCoreResult>>();


                if (string.IsNullOrWhiteSpace(signStepOneXadesCoreResult.Error))
                {
                    result.KeyID = signStepOneXadesCoreResult.Result.KeyID;
                    result.KeySecret = signStepOneXadesCoreResult.Result.KeySecret;
                    result.State = signStepOneXadesCoreResult.Result.State;
                    result.OperationId = signStepOneXadesCoreResult.Result.OperationId;
                }
                else
                {
                    result.Error = signStepOneXadesCoreResult.Error;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateStateOnOnaylarimApi");
            }
            return result;

        }

        /// <summary>
        /// Xades e-imza atma işlemi için son adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForXadesV2")]
        public async Task<ProxyFinishSignResult> FinishSignForXadesV2(ProxyFinishSignForXadesRequestV2 request)
        {
            _logger.LogInformation("FinishSign");

            var result = new ProxyFinishSignResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepThreeXadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiXades/signStepThreeXadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreeXadesCoreRequestV2
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = request.SignatureLevel,

                                        })
                                .ReceiveJson<ApiResult<SignStepThreeXadesCoreResult>>();

                if (string.IsNullOrWhiteSpace(signStepThreeXadesCoreResult.Error) == false)
                {

                }

                result.IsSuccess = signStepThreeXadesCoreResult.Result.IsSuccess;
                result.OperationId = signStepThreeXadesCoreResult.Result.OperationId;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSign");
            }

            return result;
        }

        /// <summary>
        /// Xades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListXadesV2")]
        public async Task<ProxyGetSignatureListResult> GetSignatureListXadesV2(Guid operationId)
        {
            var result = new ProxyGetSignatureListResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiXades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreResult>>();

                if (getSignatureListCoreResult.Result.Signatures != null)
                {
                    result.Signatures = getSignatureListCoreResult.Result.Signatures
                        .Select(x => new ProxyGetSignatureListResultItem()
                        {
                            ClaimedSigningTime = x.ClaimedSigningTime,
                            EntityLabel = x.EntityLabel,
                            Level = x.Level,
                            LevelString = x.LevelString,
                            SubjectRDN = x.SubjectRDN,
                            Timestamped = x.Timestamped,
                            CitizenshipNo = x.CitizenshipNo,
                            XadesSignatureType = x.XadesSignatureType
                        });
                }





            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }

        /// <summary>
        /// Xades imzalı bir belgenin e-imzalarını zenginleştirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("UpgradeXadesV2")]
        public async Task<IActionResult> UpgradeXadesV2(Guid operationId, int signatureLevel, string signaturePath)
        {
            ApiResult<UpgradeXadesCoreResult> upgradeXadesCoreResult = null;
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                upgradeXadesCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiXades/UpgradeXadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradeXadesCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = (SignatureLevelForXades)(signatureLevel),
                                            SignaturePath = signaturePath
                                        })
                                .ReceiveJson<ApiResult<UpgradeXadesCoreResult>>();

                if (string.IsNullOrWhiteSpace(upgradeXadesCoreResult.Error) == false)
                {
                    return BadRequest("İmza zenginleştirilemedi. Hata: " + upgradeXadesCoreResult.Error);
                }
                if (upgradeXadesCoreResult.Result.IsSuccess == false)
                {
                    return BadRequest("İmza zenginleştirilemedi.");
                }

                return Ok(upgradeXadesCoreResult.Result.OperationId);


            }
            catch (Exception ex)
            {
            }

            if (upgradeXadesCoreResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(upgradeXadesCoreResult.Error) == false)
            {
                return BadRequest(upgradeXadesCoreResult.Error);
            }
            else if (upgradeXadesCoreResult.Result.IsSuccess == false)
            {
                return BadRequest("Hata");
            }


            return BadRequest("Hata");

        }

        #endregion

        #region Pades

        /// <summary>
        /// PADES e-imza atma işlemi için ilk adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForPadesV2")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForPadesV2(ProxyCreateStateOnOnaylarimApiForPadesRequestV2 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiV2 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();

            try
            {

                var signatureWidgetBackground = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\Signature01.jpg");

                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepOnePadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiPades/SignStepOnePadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOnePadesCoreRequestV2()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SignatureWidgetInfo = new SignatureWidgetInfo()
                                        {
                                            Width = 100f,
                                            Height = 50f,
                                            Left = 0.5f,
                                            Top = 0.03f,
                                            TransformOrigin = "left top",
                                            ImageBytes = signatureWidgetBackground,
                                            PagesToPlaceOn = new int[] { 0 },
                                            Lines = new List<LineInfo>()
                                            {
                                                    new LineInfo()
                                                    {
                                                         BottomMargin=4,
                                                         ColorHtml="#000000",
                                                         FontName="Arial",
                                                         FontSize=10,
                                                         FontStyle = "Bold",
                                                         LeftMargin=4,
                                                         RightMargin=4,
                                                         Text="Uluç Efe Öztürk",
                                                         TopMargin=4
                                                    },
                                                    new LineInfo()
                                                    {
                                                         BottomMargin=4,
                                                         ColorHtml="#FF0000",
                                                         FontName="Arial",
                                                         FontSize=10,
                                                         FontStyle = "Regular",
                                                         LeftMargin=4,
                                                         RightMargin=4,
                                                         Text="2022-11-11",
                                                         TopMargin=4
                                                    }
                                            }
                                        }
                                    })
                            .ReceiveJson<ApiResult<SignStepOnePadesCoreResult>>();


                if (string.IsNullOrWhiteSpace(signStepOnePadesCoreResult.Error))
                {
                    result.KeyID = signStepOnePadesCoreResult.Result.KeyID;
                    result.KeySecret = signStepOnePadesCoreResult.Result.KeySecret;
                    result.State = signStepOnePadesCoreResult.Result.State;
                    result.OperationId = signStepOnePadesCoreResult.Result.OperationId;
                }
                else
                {
                    result.Error = signStepOnePadesCoreResult.Error;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateStateOnOnaylarimApi");
            }
            return result;

        }

        /// <summary>
        /// PADES e-imza atma işlemi için son adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForPadesV2")]
        public async Task<ProxyFinishSignResult> FinishSignForPadesV2(ProxyFinishSignForPadesRequestV2 request)
        {
            _logger.LogInformation("FinishSign");

            var result = new ProxyFinishSignResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepThreePadesCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiPades/signStepThreePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreePadesCoreRequestV2
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = request.SignatureLevel
                                        })
                                .ReceiveJson<ApiResult<SignStepThreePadesCoreResult>>();

                result.IsSuccess = signStepThreePadesCoreResult.Result.IsSuccess;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSign");
            }

            return result;
        }

        /// <summary>
        /// Pades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListPadesV2")]
        public async Task<ProxyGetSignatureListResult> GetSignatureListPadesV2(Guid operationId)
        {
            var result = new ProxyGetSignatureListResult();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V2/CoreApiPades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreResult>>();

                result.Signatures = getSignatureListCoreResult.Result.Signatures
                        .Select(x => new ProxyGetSignatureListResultItem()
                        {
                            ClaimedSigningTime = x.ClaimedSigningTime,
                            EntityLabel = x.EntityLabel,
                            Level = x.Level,
                            LevelString = x.LevelString,
                            SubjectRDN = x.SubjectRDN,
                            Timestamped = x.Timestamped,
                            CitizenshipNo = x.CitizenshipNo
                        });



            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }

        /// <summary>
        /// Pades imzalı bir belgenin e-imzalarını zenginleştirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("UpgradePadesV2")]
        public async Task<IActionResult> UpgradePadesV2(Guid operationId, int signatureLevel, string signaturePath)
        {
            ApiResult<UpgradePadesCoreResult> upgradePadesCoreResult = null;
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                upgradePadesCoreResult = await $"{_onaylarimServiceUrl}/v2/CoreApiPades/UpgradePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradePadesCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            SignatureLevel = (SignatureLevelForPades)(signatureLevel),
                                            SignaturePath = signaturePath
                                        })
                                .ReceiveJson<ApiResult<UpgradePadesCoreResult>>();

                if (string.IsNullOrWhiteSpace(upgradePadesCoreResult.Error) == false)
                {
                    return BadRequest("İmza zenginleştirilemedi. Hata: " + upgradePadesCoreResult.Error);
                }
                if (upgradePadesCoreResult.Result.IsSuccess == false)
                {
                    return BadRequest("İmza zenginleştirilemedi.");
                }

                return Ok(upgradePadesCoreResult.Result.OperationId);


            }
            catch (Exception ex)
            {
            }

            if (upgradePadesCoreResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(upgradePadesCoreResult.Error) == false)
            {
                return BadRequest(upgradePadesCoreResult.Error);
            }
            else if (upgradePadesCoreResult.Result.IsSuccess == false)
            {
                return BadRequest("Hata");
            }


            return BadRequest("Hata");

        }

        #endregion





    }


}


