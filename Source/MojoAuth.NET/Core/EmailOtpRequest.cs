using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class EmailOtpRequest : HttpRequest
    {
        public EmailOtpRequest(string email) : base("/users/emailotp", HttpMethod.Post, typeof(EmailOtpResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new EmailOtpPayload { Email = email };
            this.Body = body;
        }
    }

    [DataContract]
    public class EmailOtpPayload
    {
        [DataMember(Name = "email")]
        public string Email;
    }

    [DataContract]
    public class EmailOtpResponse
    {
        [DataMember(Name = "state_id")]
        public string StateId;
    }
}
