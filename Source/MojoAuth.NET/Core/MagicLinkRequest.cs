using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class SendMagicLinkRequest : HttpRequest
    {
        public SendMagicLinkRequest(string email) : base("/users/magiclink", HttpMethod.Post, typeof(SendMagicLinkResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new SendMagicLinkPayload { Email = email};
            this.Body = body;
        }
    }

    [DataContract]
    public class SendMagicLinkPayload
    {
        [DataMember(Name = "email")]
        public string Email;
    }

    [DataContract]
    public class SendMagicLinkResponse
    {
        [DataMember(Name = "state_id")]
        public string StateId;
    }
}
