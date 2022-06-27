using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class SendMagicLinkRequest : HttpRequest
    {
        public SendMagicLinkRequest(string email, string redirectUrl = "", string language = "") 
            : base($"/users/magiclink?redirect_url={redirectUrl}&language={language}", HttpMethod.Post, typeof(SendMagicLinkResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new SendMagicLinkPayload { Email = email};
            this.Body = body;
        }
    }

    [DataContract]
    public class SendMagicLinkPayload
    {
        [JsonPropertyName("email")]
        [DataMember(Name = "email")]
        public string Email;

        [JsonPropertyName("language")]
        [DataMember(Name = "language", EmitDefaultValue = true, IsRequired = false)]
        public string Language;

        [JsonPropertyName("redirect_url")]
        [DataMember(Name = "redirect_url", EmitDefaultValue = true, IsRequired = false)]
        public string RedirectUrl;
    }

    [DataContract]
    public class SendMagicLinkResponse
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId { get; set; }
    }
}
