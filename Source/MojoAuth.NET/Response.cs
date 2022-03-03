using MojoAuth.NET.Http;

namespace MojoAuth.NET
{
    public class Response<T> : HttpResponse
    {
        public Response(HttpResponse httpResponse)
        {
            this.Result = (T) httpResponse.result;
            this.Error = httpResponse.Error;
            this.Exception = httpResponse.Exception;
            this.StatusCode = httpResponse.StatusCode;
        }

        public T Result { get; set; }
    }
}
