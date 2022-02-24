using System;
using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class LoginWebAuthnFinish : HttpRequest
    {
        public LoginWebAuthnFinish(string stateId,string email,string id,string rawId,string type,string txAuthSimple) : base($"/webauthn/login/finish?state_id={stateId}&email{email}", HttpMethod.Post, typeof(LoginWebAuthnFinishResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var response = new LoginExtensions { TxAuthSimple = txAuthSimple};
            var body = new LoginWebAuthnFinishPayload { Id = id,RawId = rawId, Type = type, Extensions = response };
            this.Body = body;
        }
    }

    [DataContract]
    public class LoginExtensions
    {
        [DataMember(Name = "txAuthSimple")]
        public string TxAuthSimple { get; set; }
    }

    [DataContract]
    public class LoginWebAuthnFinishPayload
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "rawId")]
        public string RawId { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "extensions")]
        public LoginExtensions Extensions { get; set; }
    }

    [DataContract]
    public class LoginWebAuthnFinishResponse
    {
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }
        
        [DataMember(Name = "oauth")]
        public Oauth OAuth { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }


}
