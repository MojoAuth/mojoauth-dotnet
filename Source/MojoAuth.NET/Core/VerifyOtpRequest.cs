using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class VerifyOtpRequest : HttpRequest
    {
        public VerifyOtpRequest(string stateId, string otp) : base("/users/emailotp/verify", HttpMethod.Post, typeof(VerifyOtpResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new VerifyOtpPayload { StateId = stateId, OTP = otp };
            this.Body = body;
        }
    }

    [DataContract]
    public class VerifyOtpPayload
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId;       
        
        [JsonPropertyName("otp")]
        [DataMember(Name = "otp")]
        public string OTP;
    }

    [DataContract]
    public class VerifyOtpResponse : AuthenticationStatusResponse
    {
    }
}
