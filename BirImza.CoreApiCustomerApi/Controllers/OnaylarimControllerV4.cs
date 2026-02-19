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

    }
}
