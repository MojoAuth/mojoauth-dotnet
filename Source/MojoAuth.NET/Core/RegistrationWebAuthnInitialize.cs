using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class RegistrationWebAuthnInitialize : HttpRequest
    {
        public RegistrationWebAuthnInitialize(string token) : base("/webauthn/registration/initialize", HttpMethod.Get, typeof(RegistrationWebAuthnInitializeResponse))
        {
            this.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    [DataContract]
    public class RegistrationWebAuthnInitializeResponse
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId{ get; set; }

        [JsonPropertyName("publicKey")]
        [DataMember(Name = "publicKey")]
        public RegistrationPublicKey PublicKey { get; set; }
    }

    [DataContract]
    public class Rp
    {
        [JsonPropertyName("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class RegistrationUser
    {
        [JsonPropertyName("name")]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [JsonPropertyName("displayName")]
        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("id")]
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class RegistrationPubKeyCredParam
    {
        [JsonPropertyName("type")]
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [JsonPropertyName("alg")]
        [DataMember(Name = "alg")]
        public int Alg { get; set; }
    }

    [DataContract]
    public class AuthenticatorSelection
    {
        [JsonPropertyName("requireResidentKey")]
        [DataMember(Name = "requireResidentKey")]
        public bool RequireResidentKey { get; set; }

        [JsonPropertyName("userVerification")]
        [DataMember(Name = "userVerification")]
        public string UserVerification { get; set; }
    }

    [DataContract]
    public class RegistrationPublicKey
    {
        [JsonPropertyName("challenge")]
        [DataMember(Name = "challenge")]
        public string Challenge { get; set; }

        [JsonPropertyName("rp")]
        [DataMember(Name = "rp")]
        public Rp Rp { get; set; }

        [JsonPropertyName("user")]
        [DataMember(Name = "user")]
        public RegistrationUser RegistrationUser { get; set; }

        [JsonPropertyName("pubKeyCredParams")]
        [DataMember(Name = "pubKeyCredParams")]
        public List<RegistrationPubKeyCredParam> RegistrationPubKeyCredParams { get; set; }

        [JsonPropertyName("authenticatorSelection")]
        [DataMember(Name = "authenticatorSelection")]
        public AuthenticatorSelection AuthenticatorSelection { get; set; }

        [JsonPropertyName("timeout")]
        [DataMember(Name = "timeout")]
        public int Timeout { get; set; }

        [JsonPropertyName("attestation")]
        [DataMember(Name = "attestation")]
        public string Attestation { get; set; }
    }
}
