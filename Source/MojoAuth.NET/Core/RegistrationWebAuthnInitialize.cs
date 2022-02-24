using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
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
        [DataMember(Name = "state_id")]
        public string StateId{ get; set; }

        [DataMember(Name = "publicKey")]
        public PublicKey PublicKey { get; set; }
        
    }

    [DataContract]
    public class Rp
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class RegistrationUser
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    [DataContract]
    public class RegistrationPubKeyCredParam
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "alg")]
        public int Alg { get; set; }
    }

    [DataContract]
    public class AuthenticatorSelection
    {
        [DataMember(Name = "requireResidentKey")]
        public bool RequireResidentKey { get; set; }

        [DataMember(Name = "userVerification")]
        public string UserVerification { get; set; }
    }

    [DataContract]
    public class RegistrationPublicKey
    {
        [DataMember(Name = "challenge")]
        public string Challenge { get; set; }

        [DataMember(Name = "rp")]
        public Rp Rp { get; set; }

        [DataMember(Name = "user")]
        public RegistrationUser RegistrationUser { get; set; }

        [DataMember(Name = "pubKeyCredParams")]
        public List<RegistrationPubKeyCredParam> RegistrationPubKeyCredParams { get; set; }

        [DataMember(Name = "authenticatorSelection")]
        public AuthenticatorSelection AuthenticatorSelection { get; set; }

        [DataMember(Name = "timeout")]
        public int Timeout { get; set; }

        [DataMember(Name = "attestation")]
        public string Attestation { get; set; }
    }



}
