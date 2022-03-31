using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class VerifyPhoneOtpRequest : HttpRequest
    {
        public VerifyPhoneOtpRequest(string stateId, string otp) : base("/users/phone/verify", HttpMethod.Post, typeof(VerifyPhoneOtpResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new VerifyPhoneOtpPayload { StateId = stateId, OTP = otp };
            this.Body = body;
        }
    }

    [DataContract]
    public class VerifyPhoneOtpPayload
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId;       
        
        [JsonPropertyName("otp")]
        [DataMember(Name = "otp")]
        public string OTP;
    }

    [DataContract]
    public class VerifyPhoneOtpResponse : AuthenticationStatusResponse
    {
    }
}
