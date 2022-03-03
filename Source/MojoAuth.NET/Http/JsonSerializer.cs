using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MojoAuth.NET.Http
{
    public class JsonSerializer : ISerializer
    {
        public string GetContentTypeRegexPattern()
        {
            return BaseConstants.ContentTypeApplicationJson;
        }

        public async Task<object> Decode(HttpContent content, Type responseType)
        {
            var jsonSerializer = new DataContractJsonSerializer(responseType);
            var jsonString = await content.ReadAsByteArrayAsync();

            using (var ms = new MemoryStream(jsonString))
            {
                return jsonSerializer.ReadObject(ms);
            }
        }

        public HttpContent Encode(HttpRequest request)
        {
            var jsonSerializer = new DataContractJsonSerializer(request.Body.GetType());

            using (var ms = new MemoryStream())
            {
                jsonSerializer.WriteObject(ms, request.Body);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    return new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");
                }
            }
        }
    }
}
