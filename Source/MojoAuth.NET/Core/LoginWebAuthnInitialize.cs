using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class LoginWebAuthnInitialize : HttpRequest
    {
        public LoginWebAuthnInitialize(string email) : base($"/webauthn/login/initialize?email={email}", HttpMethod.Get, typeof(LoginWebAuthnInitializeResponse))
        {
        }
    }



    [DataContract]
    public class AllowCredential
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }
    }

    public class Extensions
    {
        [DataMember(Name = "txAuthSimple")]
        public string TxAuthSimple { get; set; }
    }

    public class PublicKey
    {
        [DataMember(Name = "challenge")]
        public string Challenge { get; set; }

        [DataMember(Name = "timeout")]
        public int Timeout { get; set; }

        [DataMember(Name = "rpId")]
        public string RpId { get; set; }

        [DataMember(Name = "userVerification")]
        public string UserVerification { get; set; }

        [DataMember(Name = "allowCredentials")]
        public List<AllowCredential> AllowCredentials { get; set; }

        [DataMember(Name = "extensions")]
        public Extensions Extensions { get; set; }
    }

    public class LoginWebAuthnInitializeResponse
    {
        [DataMember(Name = "state_id")]
        public string StateId { get; set; }

        [DataMember(Name = "publicKey")]
        public PublicKey PublicKey { get; set; }
    }




}
