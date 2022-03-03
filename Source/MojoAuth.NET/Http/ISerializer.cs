using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MojoAuth.NET.Http
{
	public interface ISerializer
    {
        string GetContentTypeRegexPattern();
        HttpContent Encode(HttpRequest request);
        Task<object> Decode(HttpContent content, Type responseType);
    }
}
