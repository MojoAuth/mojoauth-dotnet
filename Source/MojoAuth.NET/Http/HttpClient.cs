using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MojoAuth.NET.Exception;

namespace MojoAuth.NET.Http
{
    public class HttpClient
    {
        public Encoder Encoder { get; }
        private System.Net.Http.HttpClient client;
        private List<IInjector> injectors;

        public HttpClient(string key, string secret)
        {
            this.injectors = new List<IInjector>();
            this.Encoder = new Encoder();

            client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(BaseConstants.BaseUrl);
            client.DefaultRequestHeaders.Add("User-Agent", GetUserAgent());
            client.DefaultRequestHeaders.Add(BaseConstants.KeyAuthorizationHeader, key);
            client.DefaultRequestHeaders.Add(BaseConstants.SecretAuthorizationHeader, secret);
        }

        protected virtual string GetUserAgent()
        {
            return BaseConstants.UserAgent;
        }

        public void AddInjector(IInjector injector)
        {
            if (injector != null)
            {
                this.injectors.Add(injector);
            }
        }

        public void SetConnectTimeout(TimeSpan timeout)
        {
            client.Timeout = timeout;
        }

        public virtual async Task<HttpResponse> Execute<T>(T req) where T: HttpRequest
        {
            var request = req.Clone<T>();

            foreach (var injector in injectors) {
                injector.Inject(request);
            }

            request.RequestUri = new Uri(BaseConstants.BaseUrl + request.Path);

            if (request.Body != null)
            {
                request.Content = Encoder.SerializeRequest(request);
            }

			var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                object responseBody = null;
                if (response.Content.Headers.ContentType != null)
                {
                    responseBody = Encoder.DeserializeResponse(response.Content, request.ResponseType);
                }
                return new HttpResponse(response.StatusCode, responseBody);
            }

            if (response.Content.Headers.ContentLength != null && response.Content.Headers.ContentLength > 0)
            {
                var errorBody = (MojoAuthError)Encoder.DeserializeResponse(response.Content, typeof(MojoAuthError));
                return new HttpResponse(response.StatusCode, errorBody);
            }
            
            var resp = await response.Content.ReadAsStringAsync();
            var exception = new HttpException(response.StatusCode, response.Headers, resp);
            return new HttpResponse(exception);
        }
    }
}
