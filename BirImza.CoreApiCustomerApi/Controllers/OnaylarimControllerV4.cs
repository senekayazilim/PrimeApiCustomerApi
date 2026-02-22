using BirImza.Types;
using BirImza.Types.Shared;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirImza.CoreApiCustomerApi.Controllers
{
    public partial class OnaylarimController : ControllerBase
    {

        #region Cades V4

        /// <summary>
        /// V4 CAdES e-imza atma işlemi için ilk adımdır.
        /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForCadesV4")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForCadesV4(ProxyCreateStateOnOnaylarimApiForCadesRequestV4 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiForCadesV4 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();

            try
            {
                var signStepOneCadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiCades/SignStepOneCadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOneCadesCoreRequestV4()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SerialOrParallel = request.SerialOrParallel,
                                        SignaturePath = request.SignaturePath,
                                        SignatureLevel = request.SignatureLevel,
                                        Profile = request.Profile,
                                        HashAlgorithm = request.HashAlgorithm,
                                        Detached = request.Detached,
                                        OriginalFileOperationId = request.OriginalFileOperationId,
                                    })
                            .ReceiveJson<ApiResult<SignStepOneCadesCoreResultV4>>();

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
                _logger.LogError(ex, "CreateStateOnOnaylarimApiForCadesV4");
            }
            return result;
        }

        /// <summary>
        /// V4 CAdES e-imza atma işlemi için son adımdır.
        /// İstemcinin imzaladığı veri ile imza tamamlanır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForCadesV4")]
        public async Task<ProxyFinishSignResult> FinishSignForCadesV4(ProxyFinishSignForCadesRequestV4 request)
        {
            _logger.LogInformation("FinishSignForCadesV4");

            var result = new ProxyFinishSignResult();

            try
            {
                var signStepThreeCadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiCades/SignStepThreeCadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreeCadesCoreRequestV4
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<SignStepThreeCadesCoreResultV4>>();

                result.IsSuccess = signStepThreeCadesCoreResult.Result.IsSuccess;
                result.OperationId = signStepThreeCadesCoreResult.Result.OperationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSignForCadesV4");
            }

            return result;
        }

        /// <summary>
        /// V4 CAdES imzalı bir belgenin içindeki imzaların detaylı bilgisini alır.
        /// Detached imzalar için OriginalFileOperationId gönderilebilir.
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSignatureListCadesV4")]
        public async Task<ProxyGetSignatureListCadesResultV4> GetSignatureListCadesV4([FromBody] ProxyGetSignatureListCadesRequestV4 request)
        {
            var result = new ProxyGetSignatureListCadesResultV4();

            try
            {
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiCades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            OriginalFileOperationId = request.OriginalFileOperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCadesCoreResultV4>>();

                if (string.IsNullOrWhiteSpace(getSignatureListCoreResult.Error))
                {
                    result.OperationId = getSignatureListCoreResult.Result.OperationId;
                    result.IsDetached = getSignatureListCoreResult.Result.IsDetached;
                    if (getSignatureListCoreResult.Result.Signatures != null)
                    {
                        result.Signatures = getSignatureListCoreResult.Result.Signatures
                            .Select(x => new ProxyCadesSignatureInfoV4()
                            {
                                EntityLabel = x.EntityLabel,
                                Level = x.Level,
                                LevelString = x.LevelString,
                                SubjectRDN = x.SubjectRDN,
                                CitizenshipNo = x.CitizenshipNo,
                                Timestamped = x.Timestamped,
                                ClaimedSigningTime = x.ClaimedSigningTime,
                                ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                                Scope = x.Scope,
                                ParentEntity = x.ParentEntity,
                                ProfileName = x.ProfileName,
                                PolicyOID = x.PolicyOID,
                                HashAlgorithm = x.HashAlgorithm,
                                ContainsLongTermInfo = x.ContainsLongTermInfo,
                                LastArchivalTime = x.LastArchivalTime,
                                Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV4()
                                {
                                    EntityLabel = x.Timestamp.EntityLabel,
                                    Time = x.Timestamp.Time,
                                    TimeAsTime = x.Timestamp.TimeAsTime,
                                    TSAName = x.Timestamp.TSAName,
                                    HashAlgorithm = x.Timestamp.HashAlgorithm,
                                    TimestampType = x.Timestamp.TimestampType,
                                    TimestampTypeStr = x.Timestamp.TimestampTypeStr,
                                } : null,
                                UpgradeOptions = x.UpgradeOptions,
                                ProfileRecommendedUpgrades = x.ProfileRecommendedUpgrades,
                                ProfileIncompatibleUpgrades = x.ProfileIncompatibleUpgrades,
                            }).ToList();
                    }
                }
                else
                {
                    result.Error = getSignatureListCoreResult.Error;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// V4 CAdES imzalı bir belgenin e-imzalarını zenginleştirir (upgrade).
        /// Detached imzalar için OriginalFileOperationId gönderilebilir.
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpgradeCadesV4")]
        public async Task<IActionResult> UpgradeCadesV4([FromBody] ProxyUpgradeCadesRequestV4 request)
        {
            ApiResult<UpgradeCadesCoreResultV4> upgradeCadesCoreResult = null;
            try
            {
                upgradeCadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiCades/UpgradeCadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradeCadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            TargetLevel = request.TargetLevel,
                                            SignaturePath = request.SignaturePath,
                                            OriginalFileOperationId = request.OriginalFileOperationId,
                                        })
                                .ReceiveJson<ApiResult<UpgradeCadesCoreResultV4>>();

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

        #region Pades V4

        /// <summary>
        /// V4 PAdES e-imza atma işlemi için ilk adımdır.
        /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
        /// PAdES'te detached mod ve serial/parallel kavramı yoktur.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForPadesV4")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForPadesV4(ProxyCreateStateOnOnaylarimApiForPadesRequestV4 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiForPadesV4 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();

            try
            {
                var signStepOnePadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiPades/SignStepOnePadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOnePadesCoreRequestV4()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SignatureLevel = request.SignatureLevel,
                                        Profile = request.Profile,
                                        HashAlgorithm = request.HashAlgorithm,
                                        SignatureWidgetInfo = request.SignatureWidgetInfo != null ? new SignatureWidgetInfo()
                                        {
                                            Width = request.SignatureWidgetInfo.Width,
                                            Height = request.SignatureWidgetInfo.Height,
                                            Left = request.SignatureWidgetInfo.Left,
                                            Right = request.SignatureWidgetInfo.Right,
                                            Top = request.SignatureWidgetInfo.Top,
                                            Bottom = request.SignatureWidgetInfo.Bottom,
                                            TransformOrigin = request.SignatureWidgetInfo.TransformOrigin,
                                            ImageBytes = request.SignatureWidgetInfo.ImageBytes,
                                            PagesToPlaceOn = request.SignatureWidgetInfo.PagesToPlaceOn,
                                            Lines = request.SignatureWidgetInfo.Lines?.Select(l => new LineInfo()
                                            {
                                                Text = l.Text,
                                                LeftMargin = l.LeftMargin,
                                                TopMargin = l.TopMargin,
                                                BottomMargin = l.BottomMargin,
                                                RightMargin = l.RightMargin,
                                                FontName = l.FontName,
                                                FontSize = l.FontSize,
                                                FontStyle = l.FontStyle,
                                                ColorHtml = l.ColorHtml,
                                            }).ToList(),
                                        } : null,
                                    })
                            .ReceiveJson<ApiResult<SignStepOnePadesCoreResultV4>>();

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
                _logger.LogError(ex, "CreateStateOnOnaylarimApiForPadesV4");
            }
            return result;
        }

        /// <summary>
        /// V4 PAdES e-imza atma işlemi için son adımdır.
        /// İstemcinin imzaladığı veri ile imza tamamlanır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForPadesV4")]
        public async Task<ProxyFinishSignResult> FinishSignForPadesV4(ProxyFinishSignForPadesRequestV4 request)
        {
            _logger.LogInformation("FinishSignForPadesV4");

            var result = new ProxyFinishSignResult();

            try
            {
                var signStepThreePadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiPades/SignStepThreePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreePadesCoreRequestV4
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<SignStepThreePadesCoreResultV4>>();

                result.IsSuccess = signStepThreePadesCoreResult.Result.IsSuccess;
                result.OperationId = signStepThreePadesCoreResult.Result.OperationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSignForPadesV4");
            }

            return result;
        }

        /// <summary>
        /// V4 PAdES imzalı bir PDF belgenin içindeki imzaların detaylı bilgisini alır.
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSignatureListPadesV4")]
        public async Task<ProxyGetSignatureListPadesResultV4> GetSignatureListPadesV4([FromBody] ProxyGetSignatureListPadesRequestV4 request)
        {
            var result = new ProxyGetSignatureListPadesResultV4();

            try
            {
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiPades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListPadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListPadesCoreResultV4>>();

                if (string.IsNullOrWhiteSpace(getSignatureListCoreResult.Error))
                {
                    result.OperationId = getSignatureListCoreResult.Result.OperationId;
                    if (getSignatureListCoreResult.Result.Signatures != null)
                    {
                        result.Signatures = getSignatureListCoreResult.Result.Signatures
                            .Select(x => new ProxyPadesSignatureInfoV4()
                            {
                                EntityLabel = x.EntityLabel,
                                Level = x.Level,
                                LevelString = x.LevelString,
                                SubjectRDN = x.SubjectRDN,
                                CitizenshipNo = x.CitizenshipNo,
                                Timestamped = x.Timestamped,
                                ClaimedSigningTime = x.ClaimedSigningTime,
                                ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                                ProfileName = x.ProfileName,
                                PolicyOID = x.PolicyOID,
                                HashAlgorithm = x.HashAlgorithm,
                                ContainsLongTermInfo = x.ContainsLongTermInfo,
                                Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV4()
                                {
                                    EntityLabel = x.Timestamp.EntityLabel,
                                    Time = x.Timestamp.Time,
                                    TimeAsTime = x.Timestamp.TimeAsTime,
                                    TSAName = x.Timestamp.TSAName,
                                    HashAlgorithm = x.Timestamp.HashAlgorithm,
                                    TimestampType = x.Timestamp.TimestampType,
                                    TimestampTypeStr = x.Timestamp.TimestampTypeStr,
                                } : null,
                                UpgradeOptions = x.UpgradeOptions,
                                ProfileRecommendedUpgrades = x.ProfileRecommendedUpgrades,
                                ProfileIncompatibleUpgrades = x.ProfileIncompatibleUpgrades,
                            }).ToList();
                    }
                }
                else
                {
                    result.Error = getSignatureListCoreResult.Error;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// V4 PAdES imzalı bir belgenin e-imzalarını zenginleştirir (upgrade).
        /// NOT: B-LT'ye upgrade desteklenmez. B-LT için yeni imza atılmalıdır.
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpgradePadesV4")]
        public async Task<IActionResult> UpgradePadesV4([FromBody] ProxyUpgradePadesRequestV4 request)
        {
            ApiResult<UpgradePadesCoreResultV4> upgradePadesCoreResult = null;
            try
            {
                upgradePadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiPades/UpgradePadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradePadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            TargetLevel = request.TargetLevel,
                                            SignaturePath = request.SignaturePath,
                                        })
                                .ReceiveJson<ApiResult<UpgradePadesCoreResultV4>>();

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

        #region Xades V4

        /// <summary>
        /// V4 XAdES e-imza atma işlemi için ilk adımdır.
        /// Sunucu tarafında hash hesaplanır, istemci bu hash'i imzalar.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateStateOnOnaylarimApiForXadesV4")]
        public async Task<ProxyCreateStateOnOnaylarimApiResult> CreateStateOnOnaylarimApiForXadesV4(ProxyCreateStateOnOnaylarimApiForXadesRequestV4 request)
        {
            _logger.LogInformation("CreateStateOnOnaylarimApiForXadesV4 start");

            var result = new ProxyCreateStateOnOnaylarimApiResult();

            try
            {
                var signStepOneXadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiXades/SignStepOneXadesCore"
                            .WithHeader("X-API-KEY", _apiKey)
                            .PostJsonAsync(
                                    new SignStepOneXadesCoreRequestV4()
                                    {
                                        CerBytes = request.Certificate,
                                        OperationId = request.OperationId,
                                        RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        DisplayLanguage = "en",
                                        SerialOrParallel = request.SerialOrParallel,
                                        SignaturePath = request.SignaturePath,
                                        SignatureLevel = request.SignatureLevel,
                                        Profile = request.Profile,
                                        HashAlgorithm = request.HashAlgorithm,
                                        SignatureMode = request.SignatureMode,
                                        DetachedResourceUri = request.DetachedResourceUri,
                                        OriginalFileOperationId = request.OriginalFileOperationId,
                                        EnvelopedContentElementId = request.EnvelopedContentElementId,
                                         EnvelopingObjectEncoding = request.EnvelopingObjectEncoding,
                                            EnvelopingObjectMimeType = request.EnvelopingObjectMimeType,
                                    })
                            .ReceiveJson<ApiResult<SignStepOneXadesCoreResultV4>>();

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
                _logger.LogError(ex, "CreateStateOnOnaylarimApiForXadesV4");
            }
            return result;
        }

        /// <summary>
        /// V4 XAdES e-imza atma işlemi için son adımdır.
        /// İstemcinin imzaladığı veri ile imza tamamlanır.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("FinishSignForXadesV4")]
        public async Task<ProxyFinishSignResult> FinishSignForXadesV4(ProxyFinishSignForXadesRequestV4 request)
        {
            _logger.LogInformation("FinishSignForXadesV4");

            var result = new ProxyFinishSignResult();

            try
            {
                var signStepThreeXadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiXades/SignStepThreeXadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new SignStepThreeXadesCoreRequestV4
                                        {
                                            SignedData = request.SignedData,
                                            KeyId = request.KeyId,
                                            KeySecret = request.KeySecret,
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<SignStepThreeXadesCoreResultV4>>();

                result.IsSuccess = signStepThreeXadesCoreResult.Result.IsSuccess;
                result.OperationId = signStepThreeXadesCoreResult.Result.OperationId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FinishSignForXadesV4");
            }

            return result;
        }

        /// <summary>
        /// V4 XAdES imzalı bir belgenin içindeki imzaların detaylı bilgisini alır.
        /// Detached imzalar için OriginalFileOperationId gönderilebilir.
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSignatureListXadesV4")]
        public async Task<ProxyGetSignatureListXadesResultV4> GetSignatureListXadesV4([FromBody] ProxyGetSignatureListXadesRequestV4 request)
        {
            var result = new ProxyGetSignatureListXadesResultV4();

            try
            {
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiXades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListXadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            OriginalFileOperationId = request.OriginalFileOperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListXadesCoreResultV4>>();

                if (string.IsNullOrWhiteSpace(getSignatureListCoreResult.Error))
                {
                    result.OperationId = getSignatureListCoreResult.Result.OperationId;
                    result.IsDetached = getSignatureListCoreResult.Result.IsDetached;
                    result.SignatureMode = getSignatureListCoreResult.Result.SignatureMode;
                    if (getSignatureListCoreResult.Result.Signatures != null)
                    {
                        result.Signatures = getSignatureListCoreResult.Result.Signatures
                            .Select(x => new ProxyXadesSignatureInfoV4()
                            {
                                EntityLabel = x.EntityLabel,
                                Level = x.Level,
                                LevelString = x.LevelString,
                                SubjectRDN = x.SubjectRDN,
                                CitizenshipNo = x.CitizenshipNo,
                                Timestamped = x.Timestamped,
                                ClaimedSigningTime = x.ClaimedSigningTime,
                                ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                                ParentEntity = x.ParentEntity,
                                ProfileName = x.ProfileName,
                                PolicyOID = x.PolicyOID,
                                HashAlgorithm = x.HashAlgorithm,
                                ContainsLongTermInfo = x.ContainsLongTermInfo,
                                LastArchivalTime = x.LastArchivalTime,
                                Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV4()
                                {
                                    EntityLabel = x.Timestamp.EntityLabel,
                                    Time = x.Timestamp.Time,
                                    TimeAsTime = x.Timestamp.TimeAsTime,
                                    TSAName = x.Timestamp.TSAName,
                                    HashAlgorithm = x.Timestamp.HashAlgorithm,
                                    TimestampType = x.Timestamp.TimestampType,
                                    TimestampTypeStr = x.Timestamp.TimestampTypeStr,
                                } : null,
                                SignatureMode = x.SignatureMode,
                                UpgradeOptions = x.UpgradeOptions,
                                ProfileRecommendedUpgrades = x.ProfileRecommendedUpgrades,
                                ProfileIncompatibleUpgrades = x.ProfileIncompatibleUpgrades,
                            }).ToList();
                    }
                }
                else
                {
                    result.Error = getSignatureListCoreResult.Error;
                }
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;
        }

        /// <summary>
        /// V4 XAdES imzalı bir belgenin e-imzalarını zenginleştirir (upgrade).
        /// Detached imzalar için OriginalFileOperationId gönderilebilir.
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpgradeXadesV4")]
        public async Task<IActionResult> UpgradeXadesV4([FromBody] ProxyUpgradeXadesRequestV4 request)
        {
            ApiResult<UpgradeXadesCoreResultV4> upgradeXadesCoreResult = null;
            try
            {
                upgradeXadesCoreResult = await $"{_onaylarimServiceUrl}/V4/CoreApiXades/UpgradeXadesCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new UpgradeXadesCoreRequestV4()
                                        {
                                            OperationId = request.OperationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                            DisplayLanguage = "en",
                                            TargetLevel = request.TargetLevel,
                                            SignaturePath = request.SignaturePath,
                                            OriginalFileOperationId = request.OriginalFileOperationId,
                                        })
                                .ReceiveJson<ApiResult<UpgradeXadesCoreResultV4>>();

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

    }
}
