using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class PhoneOtpRequest : HttpRequest
    {
        public PhoneOtpRequest(string phone) : base("/users/phone", HttpMethod.Post, typeof(PhoneResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new PhonePayload { Phone = phone };
            this.Body = body;
        }
    }

    [DataContract]
    public class PhonePayload
    {
        [JsonPropertyName("phone")]
        [DataMember(Name = "phone")]
        public string Phone;
    }

    [DataContract]
    public class PhoneResponse
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId { get; set; }
    }
}
