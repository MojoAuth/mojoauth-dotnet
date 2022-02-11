using System;
using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class AuthenticationStatusRequest : HttpRequest
    {
        public AuthenticationStatusRequest(string stateId) : base($"/users/status?state_id={stateId}", HttpMethod.Get, typeof(AuthenticationStatusResponse))
        {
        }
    }

    [DataContract]
    public class AuthenticationStatusResponse
    {
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }
        
        [DataMember(Name = "oauth")]
        public Oauth OAuth { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }

    [DataContract]
    public class Oauth
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "id_token")]
        public string IdToken { get; set; }

        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        [DataMember(Name = "expires_in")]
        public DateTime ExpiresIn { get; set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [DataMember(Name = "issuer")]
        public string Issuer { get; set; }

        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }
    }
}
