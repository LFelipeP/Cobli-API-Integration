using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobliIntegration.Services.Services
{
    public interface IRestService
    {
        public Task<RestResponse> CallAsync(string endpoint, Method method, IList<Parameter> parameters);
        public RestResponse Call(string endpoint, Method method, IList<Parameter> parameters);
    }

    public class RequestModel
    {
        public RestClient Client { get; set; }
        public RestRequest Request { get; set; }
    }

    public class Parameter
    {
        public Parameter(string format, string name, object value, ParameterType type)
        {
            Format = format;
            Value = value;
            Name = name;
            Type = type;
        }

        public string Format { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }
        public ParameterType Type { get; set; }

        public static Parameter CreateParameter(string format, string name, object value, ParameterType type)
        {
            return new Parameter(format, name, value, type);
        }

        public static Parameter CreateParameter(string name, object value, ParameterType type)
        {
            return new Parameter(null, name, value, type);
        }
    }

    public abstract class RestService : IRestService
    {
        private readonly string apiUrl;

        public RestService(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task<RestResponse> CallAsync(string endpoint, Method method, IList<Parameter> parameters)
        {
            var requestModel = CreateRestRequest(endpoint, method, parameters);

            RestResponse response = await requestModel.Client.ExecuteAsync(requestModel.Request);

            return response;
        }

        public RestResponse Call(string endpoint, Method method, IList<Parameter> parameters)
        {
            var requestModel = CreateRestRequest(endpoint, method, parameters);

            RestResponse response = requestModel.Client.Execute(requestModel.Request);

            return response;
        }

        private RequestModel CreateRestRequest(string endPoint, Method method, IList<Parameter> parameters)
        {
            RestClient client = new();

            RestRequest request = new($"{apiUrl}{(endPoint[0] == '/' ? "" : "/")}{endPoint}", method);

            if (parameters != null)
                foreach (var item in parameters)
                {
                    if (item != null)
                    {
                        if (item.Type == ParameterType.RequestBody)
                        {
                            request.AddBody(item.Value, item.Name);
                        }
                        {
                            request.AddParameter(item.Name, item.Value, item.Type);
                        }
                    }
                }

            return new RequestModel() { Client = client, Request = request };
        }
    }
}
