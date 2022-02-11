using System.Net;
using System.Runtime.Serialization;
using MojoAuth.NET.Exception;

namespace MojoAuth.NET.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpException Exception { get; set; }
        public MojoAuthError Error { get; set; }

        public object result;

        public HttpResponse(HttpStatusCode statusCode, object result)
        {
            this.StatusCode = statusCode;
            this.result = result;
        }

        public HttpResponse(HttpStatusCode statusCode, MojoAuthError error)
        {
            this.StatusCode = statusCode;
            this.Error = error;
        }

        public HttpResponse(HttpException exception)
        {
            this.StatusCode = exception.StatusCode;
            this.Exception = exception;
        }

        public HttpResponse() {}
    }

    [DataContract]
    public class MojoAuthError
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
