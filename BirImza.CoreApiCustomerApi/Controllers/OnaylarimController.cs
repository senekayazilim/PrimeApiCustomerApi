using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using System.IO;
using System.Text.Json;
using System.Xml;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Net.Http.Headers;
using BirImza.Types;
using BirImza.Types.Shared;

namespace BirImza.CoreApiCustomerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OnaylarimController : ControllerBase
    {
        private readonly ILogger<OnaylarimController> _logger;
        private IWebHostEnvironment _env;

        /// <summary>
        /// Bu adresi test ortamı için https://apitest.onaylarim.com olarak değiştirmelisiniz
        /// </summary>

        //private readonly string _onaylarimServiceUrl = "https://api.onaylarim.com";
        //private readonly string _apiKey = "06636691b3fa491e96b66d88ead994b73c25e649c2805e13b00a1e";

        private readonly string _onaylarimServiceUrl = "https://localhost:44337";
        private readonly string _apiKey = "0cff5a746a714868b2c1484acfc8b99af4a75cd294ac4a71ade420f4a22470ec";

        //private readonly string _onaylarimServiceUrl = "https://apitest.onaylarim.com";
        //private readonly string _apiKey = "0cff5a746a714868b2c148294ac4a71ade420f4a22470ec";


        public OnaylarimController(IWebHostEnvironment env, ILogger<OnaylarimController> logger)
        {
            _env = env;
            _logger = logger;
        }
        /// <summary>
        /// CADES, XADES ve PADES e-imza atma işlemi için ilk adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApi")]
        public async Task<CreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApi(CreateStateOnOnaylarimApiRequest request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApi start");

            var result = new CreateStateOnOnaylarimApiResult();

            var operationId = Guid.NewGuid();


            if (request.SignatureType == "cades")
            {
                try
                {
                    // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
                    //var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\2023-04-14_Api_Development.log");
                    var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\cades01.log");
                    //var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\cadesikiimzali.log");

                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiCades/SignStepOneCadesCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneCadesCoreRequest()
                                            {
                                                CerBytes = request.Certificate,
                                                FileData = fileData,
                                                SignatureIndex = int.MaxValue,
                                                OperationId = operationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",

                                            })
                                    .ReceiveJson<ApiResult<SignStepOneCadesCoreResult>>();

                    result.KeyID = signStepOneCoreResult.Result.KeyID;
                    result.KeySecret = signStepOneCoreResult.Result.KeySecret;
                    result.State = signStepOneCoreResult.Result.State;
                    result.OperationId = operationId;
                }
                catch (Exception ex)
                {

                }
            }
            else if (request.SignatureType == "xades")
            {




                try
                {
                    // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
                    var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.xml");

                    if (request.XmlSignatureType == 2)
                    {
                        fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");
                    }




                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiXades/SignStepOneXadesCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneXadesCoreRequest()
                                            {
                                                CerBytes = request.Certificate,
                                                FileData = fileData,
                                                SignatureIndex = 0,
                                                OperationId = operationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                XmlSignatureType = request.XmlSignatureType,
                                                EnvelopingObjectMimeType = request.EnvelopingObjectMimeType,
                                                EnvelopingObjectEncoding = request.EnvelopingObjectEncoding,
                                            })
                                    .ReceiveJson<ApiResult<SignStepOneXadesCoreResult>>();

                    result.KeyID = signStepOneCoreResult.Result.KeyID;
                    result.KeySecret = signStepOneCoreResult.Result.KeySecret;
                    result.State = signStepOneCoreResult.Result.State;
                    result.OperationId = operationId;
                }
                catch (Exception ex)
                {

                }
            }

            else if (request.SignatureType == "pades")
            {


                try
                {

                    // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                    var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\uni.pdf");
                    var signatureWidgetBackground = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\Signature01.jpg");

                    // Önce uploadFileBeforeOperation'a göre karar ver
                    var uploadFileBeforeOperation = false;
                    var preUploaded = false;

                    if (uploadFileBeforeOperation)
                    {
                        // Büyük dosyalarda chunked upload kullan, küçüklerde mevcut yol (tek parça upload)
                        var chunkSize = 8 * 1024 * 1024; // 8MB
                        var useChunkedUpload = fileData.Length > chunkSize;

                        if (useChunkedUpload)
                        {
                            Guid? uploadSessionId = null;
                            // 1) ChunkInit
                            var totalChunks = (int)Math.Ceiling((double)fileData.Length / chunkSize);
                            var initResult = await $"{_onaylarimServiceUrl}/CoreApiPades/ChunkInit"
                                                .WithHeader("X-API-KEY", _apiKey)
                                                .PostJsonAsync(new InitializeChunkedUploadRequest
                                                {
                                                    OperationId = operationId,
                                                    ChunkSize = chunkSize,
                                                    TotalSize = fileData.LongLength,
                                                    TotalChunks = totalChunks,
                                                    RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                    DisplayLanguage = "en"
                                                })
                                                .ReceiveJson<ApiResult<InitializeChunkedUploadResult>>();

                            if (!string.IsNullOrWhiteSpace(initResult.Error))
                            {
                                result.Error = initResult.Error;
                                return result;
                            }

                            uploadSessionId = initResult.Result.UploadSessionId;

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

                                    var uploadChunkResult = await $"{_onaylarimServiceUrl}/CoreApiPades/ChunkUpload"
                                                                    .WithHeader("X-API-KEY", _apiKey)
                                                                    .WithHeader("uploadsessionid", uploadSessionId)
                                                                    .WithHeader("chunkindex", chunkIndex)
                                                                    .PostAsync(content)
                                                                    .ReceiveJson<ApiResult<UploadChunkResult>>();

                                    if (!string.IsNullOrWhiteSpace(uploadChunkResult.Error) || (uploadChunkResult.Result != null && uploadChunkResult.Result.Accepted == false))
                                    {
                                        await $"{_onaylarimServiceUrl}/CoreApiPades/ChunkAbort"
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
                                var completeResult = await $"{_onaylarimServiceUrl}/CoreApiPades/ChunkComplete"
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
                            }
                            catch (Exception)
                            {
                                if (uploadSessionId.HasValue)
                                {
                                    try
                                    {
                                        await $"{_onaylarimServiceUrl}/CoreApiPades/ChunkAbort"
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

                            preUploaded = true;
                        }
                        else
                        {
                            // Mevcut tek parça yükleme yolu (SignStepOneUploadFile)
                            var signStepOneUploadFileResult = await $"{_onaylarimServiceUrl}/CoreApiPades/SignStepOneUploadFile"
                                             .WithHeader("X-API-KEY", _apiKey)
                                             .WithHeader("operationid", operationId)
                                             .PostMultipartAsync(mp => mp
                                                     .AddFile("file", $@"{_env.ContentRootPath}\Resources\sample.pdf", null, 4096, "sample.pdf")
                                             )
                                             .ReceiveJson<ApiResult<SignStepOneUploadFileResult>>();
                            if (!string.IsNullOrWhiteSpace(signStepOneUploadFileResult.Error))
                            {
                                result.Error = signStepOneUploadFileResult.Error;
                                return result;
                            }
                            preUploaded = true;
                        }
                    }

                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPades/SignStepOnePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepOnePadesCoreRequest()
                                        {
                                            CerBytes = request.Certificate,
                                            FileData = preUploaded ? new byte[] { } : fileData,

                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            //VerificationInfo = new VerificationInfo()
                                            //{
                                            //    Text = "Bu belge 5070 sayılı elektronik imza kanununa göre güvenli elektronik imza ile imzalanmıştır. Belgeye\r\nhttps://localhost:8082 adresinden 97275466-4A90128E46284E3181CF21020554BFEC452DBDE73",
                                            //    Width = 0.8f,
                                            //    Height = 0.1f,
                                            //    Left = 0.1f,
                                            //    Bottom = 0.03f,
                                            //    TransformOrigin = "left bottom"
                                            //},
                                            //QrCodeInfo = new QrCodeInfo()
                                            //{
                                            //    Text = "google.com",
                                            //    Width = 0.1f,
                                            //    Right = 0.03f,
                                            //    Top = 0.02f,
                                            //    TransformOrigin = "right top"
                                            //},
                                            //SignatureWidgetInfo = new SignatureWidgetInfo()
                                            //{
                                            //    Width = 100f,
                                            //    Height = 50f,
                                            //    Left = 0.5f,
                                            //    Top = 0.03f,
                                            //    TransformOrigin = "left top",
                                            //    ImageBytes = signatureWidgetBackground,
                                            //    PagesToPlaceOn = new int[] { 0 },
                                            //    Lines = new List<LineInfo>()
                                            //    {
                                            //            new LineInfo()
                                            //            {
                                            //                 BottomMargin=4,
                                            //                 ColorHtml="#000000",
                                            //                 FontName="Arial",
                                            //                 FontSize=10,
                                            //                 FontStyle = "Bold",
                                            //                 LeftMargin=4,
                                            //                 RightMargin=4,
                                            //                 Text="Uluç Efe Öztürk",
                                            //                 TopMargin=4
                                            //            },
                                            //            new LineInfo()
                                            //            {
                                            //                 BottomMargin=4,
                                            //                 ColorHtml="#FF0000",
                                            //                 FontName="Arial",
                                            //                 FontSize=10,
                                            //                 FontStyle = "Regular",
                                            //                 LeftMargin=4,
                                            //                 RightMargin=4,
                                            //                 Text="2022-11-11",
                                            //                 TopMargin=4
                                            //            }
                                            //    }
                                            //}
                                        })
                                .ReceiveJson<ApiResult<SignStepOnePadesCoreResult>>();


                    if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error))
                    {
                        result.KeyID = signStepOneCoreResult.Result.KeyID;
                        result.KeySecret = signStepOneCoreResult.Result.KeySecret;
                        result.State = signStepOneCoreResult.Result.State;
                        result.OperationId = operationId;
                    }
                    else
                    {
                        result.Error = signStepOneCoreResult.Error;
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "CreateStateOnOnaylarimApi");
                }
            }
            return result;

        }

        /// <summary>
        /// CADES, XADES ve PADES e-imza atma işlemi için son adımdır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSign")]
        public async Task<FinishSignResult> FinishSign(FinishSignRequest request)
        {
            _logger.LogInformation("FinishSign");

            var result = new FinishSignResult();

            if (request.SignatureType == "cades")
            {
                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiCades/signStepThreeCadesCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepThreeCadesCoreRequest()
                                            {
                                                SignedData = request.SignedData,
                                                KeyId = request.KeyId,
                                                KeySecret = request.KeySecret,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                SignatureLevel = SignatureLevelForCades.aslBES,
                                            })
                                    .ReceiveJson<ApiResult<SignStepThreeCadesCoreResult>>();

                    result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "FinishSign");
                }
            }
            else if (request.SignatureType == "xades")
            {



                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiXades/signStepThreeXadesCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepThreeXadesCoreRequest()
                                            {
                                                SignedData = request.SignedData,
                                                KeyId = request.KeyId,
                                                KeySecret = request.KeySecret,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en"
                                            })
                                    .ReceiveJson<ApiResult<SignStepThreeXadesCoreResult>>();

                    result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "FinishSign");
                }
            }
            else if (request.SignatureType == "pades")
            {
                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPades/signStepThreePadesCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepThreePadesCoreRequest
                                            {
                                                SignedData = request.SignedData,
                                                KeyId = request.KeyId,
                                                KeySecret = request.KeySecret,
                                                DontUpgradeToLtv = request.DontUpgradeToLtv,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en"
                                            })
                                    .ReceiveJson<ApiResult<SignStepThreePadesCoreResult>>();

                    result.IsSuccess = signStepOneCoreResult.Result.IsSuccess;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "FinishSign");
                }
            }

            return result;
        }




        /// <summary>
        /// Mobil imza atma işlemi için kullanılan metoddur
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("MobileSign")]
        public async Task<MobilSignResult> MobileSign(MobileSignRequest request)
        {
            var result = new MobilSignResult();

            var operationId = Guid.NewGuid();

            if (request.SignatureType == "cades")
            {
                // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiCadesMobile/SignStepOneCadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneCadesMobileCoreRequest()
                                            {
                                                FileData = fileData,
                                                SignatureIndex = 0,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
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
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiXadesMobile/SignStepOneXadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneXadesMobileCoreRequest()
                                            {
                                                FileData = fileData,
                                                SignatureIndex = 0,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
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
                var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\uni.pdf");

                // Yüksek boyutlu pdf dsyalarını imzalama işlemi öncesi sunucuya yükleme yapmak için kullanılır.
                var uploadFileBeforeOperation = true;
                var preUploaded = false;

                if (uploadFileBeforeOperation)
                {
                    var signStepOneUploadFileResult = await $"{_onaylarimServiceUrl}/CoreApiPades/SignStepOneUploadFile"
                                             .WithHeader("X-API-KEY", _apiKey)
                                             .WithHeader("operationid", operationId)
                                             .PostMultipartAsync(mp => mp
                                                     .AddFile("file", $@"{_env.ContentRootPath}\Resources\uni.pdf", null, 4096, "uni.pdf")
                                             )
                                             .ReceiveJson<ApiResult<SignStepOneUploadFileResult>>();
                    if (!string.IsNullOrWhiteSpace(signStepOneUploadFileResult.Error))
                    {
                        result.Error = signStepOneUploadFileResult.Error;
                        return result;
                    }
                    preUploaded = true;
                }

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPadesMobile/SignStepOnePadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOnePadesMobileCoreRequest()
                                            {
                                                FileData = preUploaded ? new byte[] { } : fileData,
                                                //SignatureIndex = 0,
                                                OperationId = operationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                VerificationInfo = new VerificationInfo()
                                                {
                                                    Text = "Bu belge 5070 sayılı elektronik imza kanununa göre güvenli elektronik imza ile imzalanmıştır. Belgeye\r\nhttps://localhost:8082 adresinden 97275466-4A90128E46284E3181CF21020554BFEC452DBDE73",
                                                    Width = 0.8f,
                                                    Height = 0.1f,
                                                    Left = 0.1f,
                                                    Bottom = 0.03f,
                                                    TransformOrigin = "left bottom"
                                                },
                                                QrCodeInfo = new QrCodeInfo()
                                                {
                                                    Text = "google.com",
                                                    Width = 0.1f,
                                                    Right = 0.03f,
                                                    Top = 0.02f,
                                                    TransformOrigin = "right top"
                                                },
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo
                                            })
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

        /// <summary>
        /// Mobil imza atma işlemi için kullanılan metoddur
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("MobileSignV2")]
        public async Task<MobilSignResult> MobileSignV2(MobileSignRequestV2 request)
        {
            var result = new MobilSignResult();

            if (request.SignatureType == "cades")
            {
                // İmzalanacak dosyayı kendi bilgisayarınızda bulunan bir pdf olarak ayarlayınız
                var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiCadesMobile/SignStepOneCadesMobileCoreV2"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneCadesMobileCoreRequestV2()
                                            {
                                                FileData = fileData,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
                                                SignatureLevel = request.SignatureLevel,
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
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiXadesMobile/SignStepOneXadesMobileCore"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOneXadesMobileCoreRequest()
                                            {
                                                FileData = fileData,
                                                SignatureIndex = 0,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
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
                var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

                try
                {
                    // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                    var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPadesMobile/SignStepOnePadesMobileCoreV2"
                                    .WithHeader("X-API-KEY", _apiKey)
                                    .PostJsonAsync(
                                            new SignStepOnePadesMobileCoreRequestV2()
                                            {
                                                FileData = fileData,
                                                OperationId = request.OperationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en",
                                                VerificationInfo = new VerificationInfo()
                                                {
                                                    Text = "Bu belge 5070 sayılı elektronik imza kanununa göre güvenli elektronik imza ile imzalanmıştır. Belgeye\r\nhttps://localhost:8082 adresinden 97275466-4A90128E46284E3181CF21020554BFEC452DBDE73",
                                                    Width = 0.8f,
                                                    Height = 0.1f,
                                                    Left = 0.1f,
                                                    Bottom = 0.03f,
                                                    TransformOrigin = "left bottom"
                                                },
                                                QrCodeInfo = new QrCodeInfo()
                                                {
                                                    Text = "google.com",
                                                    Width = 0.1f,
                                                    Right = 0.03f,
                                                    Top = 0.02f,
                                                    TransformOrigin = "right top"
                                                },
                                                PhoneNumber = request.PhoneNumber,
                                                Operator = request.Operator,
                                                UserPrompt = "CoreAPI ile belge imzalayacaksınız.",
                                                CitizenshipNo = request.CitizenshipNo,
                                                SignatureLevel = SignatureLevelForPades.paslBES,
                                                SignatureTurkishProfile = request.SignatureTurkishProfile,
                                            })
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

        [HttpPost("GetFingerPrint")]
        public async Task<GetFingerPrintResult> GetFingerPrint(GetFingerPrintRequest request)
        {
            var result = new GetFingerPrintResult();
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getFingerPrintCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPadesMobile/GetFingerPrintCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetFingerPrintCoreRequest()
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

        /// <summary>
        /// İmzalanmış dosyayı indirmek için kullanılır
        /// </summary>
        /// <param name="operationId"></param>
        /// <returns></returns>
        [HttpGet("DownloadSignedFileFromOnaylarimApi")]
        public async Task<IActionResult> DownloadSignedFileFromOnaylarimApi(Guid operationId)
        {

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var downloadSignedFileCoreResult = await $"{_onaylarimServiceUrl}/CoreApiDownload/downloadSignedFileCore"
                                        .WithHeader("X-API-KEY", _apiKey)
                                        .PostJsonAsync(
                                            new DownloadSignedFileCoreRequest()
                                            {
                                                OperationId = operationId,
                                                RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                                DisplayLanguage = "en"
                                            })
                                        .ReceiveJson<ApiResult<DownloadSignedFileCoreResult>>();

                return File(downloadSignedFileCoreResult.Result.FileData, "application/octet-stream", downloadSignedFileCoreResult.Result.FileName + ".imz");

            }
            catch (Exception ex)
            {
            }
            return BadRequest("Hata");
        }


        /// <summary>
        /// Microsoft Office ve resim dosyalarını pdf'e dönüştürür
        /// </summary>
        /// <returns></returns>
        [HttpGet("ConvertToPdf")]
        public async Task<IActionResult> ConvertToPdf()
        {
            // Dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
            var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\yeni proje.docx");

            var operationId = Guid.NewGuid();
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPdf/ConvertToPdfCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new ConvertToPdfCoreRequest()
                                        {
                                            FileData = fileData,
                                            FileName = "yeni proje.docx",
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<ConvertToPdfCoreResult>>();

                return File(signStepOneCoreResult.Result.FileData, "application/pdf", "pdf000.pdf");

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
        [HttpGet("AddLayers")]
        public async Task<IActionResult> AddLayers()
        {

            // Dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
            var fileData = System.IO.File.ReadAllBytes($@"{_env.ContentRootPath}\Resources\sample.pdf");

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPdf/AddLayersCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new AddLayersCoreRequest()
                                        {
                                            FileData = fileData,
                                            FileName = "sample.pdf",
                                            OperationId = Guid.NewGuid(),
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            VerificationInfo = new VerificationInfo()
                                            {
                                                Text = "Bu belge 5070 sayılı elektronik imza kanununa göre güvenli elektronik imza ile imzalanmıştır. Belgeye\r\nhttps://localhost:8082 adresinden 97275466-4A90128E46284E3181CF21020554BFEC452DBDE73",
                                                Width = 0.8f,
                                                Height = 0.1f,
                                                Left = 0.1f,
                                                Bottom = 0.03f,
                                                TransformOrigin = "left bottom"
                                            },
                                            QrCodeInfo = new QrCodeInfo()
                                            {
                                                Text = "google.com",
                                                Width = 0.1f,
                                                Right = 0.03f,
                                                Top = 0.02f,
                                                TransformOrigin = "right top"
                                            }
                                        })
                                .ReceiveJson<ApiResult<AddLayersCoreResult>>();

                return File(signStepOneCoreResult.Result.FileData, "application/pdf", "pdf000.pdf");

            }
            catch (Exception ex)
            {
            }
            return BadRequest("Hata");

        }

        /// <summary>
        /// Pades imzalı bir belgenin e-imzalarını zenginleştirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("UpgradePades")]
        public async Task<IActionResult> UpgradePades()
        {

            var operationId = Guid.NewGuid();

            // Dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
            var filePath = $@"{_env.ContentRootPath}\Resources\dosya (80).pdf";

            ApiResult<SignStepOneUploadFileResult> signStepOneUploadFileResult;
            try
            {
                signStepOneUploadFileResult = await $"{_onaylarimServiceUrl}/CoreApiPades/SignStepOneUploadFile"
                                        .WithHeader("X-API-KEY", _apiKey)
                                        .WithHeader("operationid", operationId)
                                        .PostMultipartAsync(mp => mp
                                                .AddFile("file", filePath, null, 4096, "dosya (80).pdf")
                                        )
                                        .ReceiveJson<ApiResult<SignStepOneUploadFileResult>>();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (signStepOneUploadFileResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(signStepOneUploadFileResult.Error) == false)
            {
                return BadRequest(signStepOneUploadFileResult.Error);
            }


            ApiResult<UpgradePadesCoreResult> signStepOneCoreResult = null;
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPades/UpgradePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradePadesCoreRequest()
                                        {
                                            OperationId = signStepOneUploadFileResult.Result.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<UpgradePadesCoreResult>>();

                return Ok(operationId);

                //return File(signStepOneCoreResult.Result.FileData, "application/pdf", "pdf000.pdf");

            }
            catch (Exception ex)
            {
            }

            if (signStepOneCoreResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error) == false)
            {
                return BadRequest(signStepOneCoreResult.Error);
            }
            else if (signStepOneCoreResult.Result.IsSuccess == false)
            {
                return BadRequest("Hata");
            }


            return BadRequest("Hata");

        }

        /// <summary>
        /// Pades imzalı bir belgenin e-imzalarını zenginleştirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("UpgradeCades")]
        public async Task<IActionResult> UpgradeCades()
        {

            var operationId = Guid.NewGuid();

            // Dosyayı kendi bilgisayarınızda bulunan bir dosya olarak ayarlayınız
            var filePath = $@"{_env.ContentRootPath}\Resources\tek imza.pdf.imz";

            ApiResult<SignStepOneUploadFileResult> signStepOneUploadFileResult;
            try
            {
                signStepOneUploadFileResult = await $"{_onaylarimServiceUrl}/CoreApiPades/SignStepOneUploadFile"
                                        .WithHeader("X-API-KEY", _apiKey)
                                        .WithHeader("operationid", operationId)
                                        .PostMultipartAsync(mp => mp
                                                .AddFile("file", filePath, null, 4096, "tek imza.pdf.imz")
                                        )
                                        .ReceiveJson<ApiResult<SignStepOneUploadFileResult>>();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (signStepOneUploadFileResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(signStepOneUploadFileResult.Error) == false)
            {
                return BadRequest(signStepOneUploadFileResult.Error);
            }


            ApiResult<UpgradeCadesCoreResult> signStepOneCoreResult = null;
            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                signStepOneCoreResult = await $"{_onaylarimServiceUrl}/CoreApiCades/UpgradeCadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradePadesCoreRequest()
                                        {
                                            OperationId = signStepOneUploadFileResult.Result.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<UpgradeCadesCoreResult>>();

                return Ok(operationId);

                //return File(signStepOneCoreResult.Result.FileData, "application/pdf", "pdf000.pdf");

            }
            catch (Exception ex)
            {
            }

            if (signStepOneCoreResult == null)
            {
                return BadRequest("Hata");
            }
            else if (string.IsNullOrWhiteSpace(signStepOneCoreResult.Error) == false)
            {
                return BadRequest(signStepOneCoreResult.Error);
            }
            else if (signStepOneCoreResult.Result.IsSuccess == false)
            {
                return BadRequest("Hata");
            }


            return BadRequest("Hata");

        }

        [HttpGet("VerifySignaturesOnOnaylarimApi")]
        public async Task<VerifySignaturesCoreResult> VerifySignaturesOnOnaylarimApi()
        {
            var result = new VerifySignaturesCoreResult();

            var operationId = Guid.NewGuid();

            try
            {

                var verifySignaturesCoreResult = await $"{_onaylarimServiceUrl}/CoreApiPades/VerifySignaturesCore"
                                     .WithHeader("X-API-KEY", _apiKey)
                                     .WithHeader("operationid", operationId)
                                     .PostMultipartAsync(mp => mp
                                             .AddFile("file", $@"{_env.ContentRootPath}\Resources\cok imzali.pdf", null, 4096, "cok imzali.pdf")
                                     )
                                     .ReceiveJson<ApiResult<VerifySignaturesCoreResult>>();

                return verifySignaturesCoreResult.Result;


            }
            catch (Exception ex)
            {
            }

            return result;

        }


        /// <summary>
        /// Cades İmzalı belgelerin doğrulanması için kullanılır
        /// </summary>
        /// <returns></returns>
        [HttpGet("VerifySignaturesCoreCadesOnOnaylarimApi")]
        public async Task<JavaPadesValidationResult> VerifySignaturesCoreCadesOnOnaylarimApi()
        {
            var result = new JavaPadesValidationResult();
            var operationId = Guid.NewGuid();
            try
            {
                var verifySignaturesCoreCadesResult = await $"{_onaylarimServiceUrl}/CoreApiCades/VerifySignaturesCoreCades"
                                     .WithHeader("X-API-KEY", _apiKey)
                                     .WithHeader("operationid", operationId)
                                     .PostMultipartAsync(mp => mp
                                             .AddFile("file", $@"{_env.ContentRootPath}\Resources\cades.p7s", null, 4096, "cades.p7s")
                                     )
                                     .ReceiveJson<ApiResult<JavaPadesValidationResult>>();
                return verifySignaturesCoreCadesResult.Result;

            }
            catch (Exception ex)
            {
            }
            return result;
        }

    }


}


