using System;
using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class RegistrationWebAuthnFinish : HttpRequest
    {
        public RegistrationWebAuthnFinish(string stateId,string id,string rawId,string type,string attestationObject,string clientDataJSON) : base($"/webauthn/registration/finish?state_id={stateId}", HttpMethod.Post, typeof(RegistrationWebAuthnFinishResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var response = new Response{AttestationObject = attestationObject, ClientDataJSON = clientDataJSON};
            var body = new RegistrationWebAuthnFinishPayload { Id = id, RawId = rawId, Type = type, Response = response };
            this.Body = body;
        }
    }

    [DataContract]
    public class Response
    {
        [DataMember(Name = "attestationObject")]
        public string AttestationObject { get; set; }

        [DataMember(Name = "clientDataJSON")]
        public string ClientDataJSON { get; set; }
        public string TxAuthSimple { get; internal set; }
    }

    [DataContract]
    public class RegistrationWebAuthnFinishPayload
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "rawId")]
        public string RawId { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "response")]
        public Response Response { get; set; }
    }

    [DataContract]
    public class RegistrationWebAuthnFinishResponse
    {
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }
        
        [DataMember(Name = "oauth")]
        public Oauth OAuth { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }

}


