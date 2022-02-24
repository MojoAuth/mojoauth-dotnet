using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class CheckWebAuthnRequest : HttpRequest
    {
        public CheckWebAuthnRequest(string email) : base($"/webauthn/check?email={email}", HttpMethod.Get, typeof(CheckWebAuthnResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new EmailOtpPayload { Email = email };
            this.Body = body;
        }
    }



    [DataContract]
    public class CheckWebAuthnResponse
    {
        [DataMember(Name = "webauthn_registered")]
        public bool WebauthnRegistered;
    
        [DataMember(Name = "first_login")]
        public bool FirstLogin;
    }
}
