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

        #region Cades

        /// <summary>
        /// Cades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListCadesV3")]
        public async Task<ProxyGetSignatureListResultV3> GetSignatureListCadesV3(Guid operationId)
        {
            var result = new ProxyGetSignatureListResultV3();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V3/CoreApiCades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreV3Result>>();

                if (getSignatureListCoreResult.Result.Signatures != null)
                {
                    result.Signatures = getSignatureListCoreResult.Result.Signatures
                       .Select(x => new ProxyGetSignatureListResultItemV3()
                       {
                           ClaimedSigningTime = x.ClaimedSigningTime,
                           EntityLabel = x.EntityLabel,
                           Level = x.Level,
                           LevelString = x.LevelString,
                           SubjectRDN = x.SubjectRDN,
                           Timestamped = x.Timestamped,
                           CitizenshipNo = x.CitizenshipNo,
                           XadesSignatureType = x.XadesSignatureType,
                           ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                           ParentEntity = x.ParentEntity,
                           Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV3()
                           {
                               EntityLabel = x.Timestamp.EntityLabel,
                               Time = x.Timestamp.Time,
                               TimeAsTime = x.Timestamp.TimeAsTime,
                           } : null,
                       });
                }





            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }


        #endregion

        #region Xades

        /// <summary>
        /// Xades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListXadesV3")]
        public async Task<ProxyGetSignatureListResultV3> GetSignatureListXadesV3(Guid operationId)
        {
            var result = new ProxyGetSignatureListResultV3();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V3/CoreApiXades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreV3Result>>();

                if (getSignatureListCoreResult.Result.Signatures != null)
                {
                    result.Signatures = getSignatureListCoreResult.Result.Signatures
                        .Select(x => new ProxyGetSignatureListResultItemV3()
                        {
                            ClaimedSigningTime = x.ClaimedSigningTime,
                            EntityLabel = x.EntityLabel,
                            Level = x.Level,
                            LevelString = x.LevelString,
                            SubjectRDN = x.SubjectRDN,
                            Timestamped = x.Timestamped,
                            CitizenshipNo = x.CitizenshipNo,
                            XadesSignatureType = x.XadesSignatureType,
                            ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                            ParentEntity = x.ParentEntity,
                            Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV3()
                            {
                                EntityLabel = x.Timestamp.EntityLabel,
                                Time = x.Timestamp.Time,
                                TimeAsTime = x.Timestamp.TimeAsTime,
                            } : null,
                        });
                }





            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }


        #endregion

        #region Pades

        /// <summary>
        /// Pades imzalı bir belgenin içindeki imzaların bilgisini alır
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSignatureListPadesV3")]
        public async Task<ProxyGetSignatureListResultV3> GetSignatureListPadesV3(Guid operationId)
        {
            var result = new ProxyGetSignatureListResultV3();

            try
            {
                // Size verilen API key'i "X-API-KEY değeri olarak ayarlayınız
                var getSignatureListCoreResult = await $"{_onaylarimServiceUrl}/V3/CoreApiPades/GetSignatureListCore"
                                .WithHeader("X-API-KEY", _apiKey)
                                .PostJsonAsync(
                                        new GetSignatureListCoreRequestV2()
                                        {
                                            OperationId = operationId,
                                            RequestId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 21),
                                        })
                                .ReceiveJson<ApiResult<GetSignatureListCoreV3Result>>();

                result.Signatures = getSignatureListCoreResult.Result.Signatures
                        .Select(x => new ProxyGetSignatureListResultItemV3()
                        {
                            ClaimedSigningTime = x.ClaimedSigningTime,
                            EntityLabel = x.EntityLabel,
                            Level = x.Level,
                            LevelString = x.LevelString,
                            SubjectRDN = x.SubjectRDN,
                            Timestamped = x.Timestamped,
                            CitizenshipNo = x.CitizenshipNo,
                            XadesSignatureType = x.XadesSignatureType,
                            ClaimedSigningTimeAsTime = x.ClaimedSigningTimeAsTime,
                            ParentEntity = x.ParentEntity,
                            Timestamp = x.Timestamp != null ? new ProxyTimestampInfoItemV3()
                            {
                                EntityLabel = x.Timestamp.EntityLabel,
                                Time = x.Timestamp.Time,
                                TimeAsTime = x.Timestamp.TimeAsTime,
                            } : null,
                        });



            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return result;

        }



        #endregion

    }


}


