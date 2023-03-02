using CobliIntegration.Domain.Cobli;
using CobliIntegration.Domain.Configuration;
using CobliIntegration.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobliIntegration.Services.Services
{
    public class CobliService : RestService, ICobliService
    {
        private readonly string cobliSecret;

        public CobliService(string apiUrl, string cobliSecret) : base(apiUrl)
        {
            this.cobliSecret = cobliSecret;
        }

        public ResponseEvent GetEvents(GetEventsFilter filter)
        {
            var parameters = new List<Parameter>
            {
                Parameter.CreateParameter("start_date", filter.StartDate, ParameterType.QueryString),
                Parameter.CreateParameter("end_date", filter.EndDate, ParameterType.QueryString),
                Parameter.CreateParameter("timezone", "America/Sao_Paulo", ParameterType.QueryString),
                Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString),
                Parameter.CreateParameter("page", filter.PageNumber, ParameterType.QueryString),
                Parameter.CreateParameter("cobli-api-key", cobliSecret, ParameterType.HttpHeader),
            };


            return JsonConvert.DeserializeObject<ResponseEvent>(Call("/risk-events", Method.Get, parameters).Content);
        }

        public MediaResponse GetMedias(GetMediaFilter filter)
        {
            var parameters = new List<Parameter>
            {
                Parameter.CreateParameter("start_datetime", filter.StartDate, ParameterType.QueryString),
                Parameter.CreateParameter("end_datetime", filter.EndDate, ParameterType.QueryString),
                Parameter.CreateParameter("timezone", "America/Sao_Paulo", ParameterType.QueryString),
                Parameter.CreateParameter("limit", filter.Limit, ParameterType.QueryString),
                Parameter.CreateParameter("page", filter.PageNumber, ParameterType.QueryString),                
                Parameter.CreateParameter("cobli-api-key", cobliSecret, ParameterType.HttpHeader),
            };

            if (filter.DriverIds != null)
                parameters.Add(Parameter.CreateParameter("driver_ids", filter.DriverIds, ParameterType.QueryString));

            if (filter.DeviceIds != null)
                parameters.Add(Parameter.CreateParameter("device_ids", filter.DeviceIds, ParameterType.QueryString));


            return JsonConvert.DeserializeObject<MediaResponse>(Call("/camera/media", Method.Get, parameters).Content);
        }

        public MediaLinkResponse GetMedia(string mediaId)
        {
            var parameters = new List<Parameter>
            {
                Parameter.CreateParameter("timezone", "America/Sao_Paulo", ParameterType.QueryString),
                Parameter.CreateParameter("cobli-api-key", cobliSecret, ParameterType.HttpHeader),
            };


            return JsonConvert.DeserializeObject<MediaLinkResponse>(Call($"/camera/media/{mediaId}", Method.Get, parameters).Content);
        }
    }        

}
