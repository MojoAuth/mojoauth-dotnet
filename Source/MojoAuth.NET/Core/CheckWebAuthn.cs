using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class CheckWebAuthnRequest : HttpRequest
    {
        public CheckWebAuthnRequest(string email) : base($"/webauthn/check?email={email}", HttpMethod.Get, typeof(CheckWebAuthnResponse))
        {
        }
    }

    [DataContract]
    public class CheckWebAuthnResponse
    {
        [JsonPropertyName("webauthn_registered")]
        [DataMember(Name = "webauthn_registered")]
        public bool WebAuthnRegistered { get; set; }

        [JsonPropertyName("first_login")]
        [DataMember(Name = "first_login")]
        public bool FirstLogin { get; set; }
    }
}
