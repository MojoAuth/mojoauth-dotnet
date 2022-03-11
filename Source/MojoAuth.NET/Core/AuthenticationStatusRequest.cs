//-----------------------------------------------------------------------
// <copyright file="AuthenticationStatusRequest.cs" company="MojoAuth">
//     Created by MojoAuth Development Team
//     Copyright 2022 MojoAuth. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("authenticated")]
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }
        
        [JsonPropertyName("oauth")]
        [DataMember(Name = "oauth")]
        public Oauth OAuth { get; set; }

        [JsonPropertyName("user")]
        [DataMember(Name = "user")]
        public User User { get; set; }
    }

    [DataContract]
    public class Oauth
    {
        [JsonPropertyName("access_token")]
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("id_token")]
        [DataMember(Name = "id_token")]
        public string IdToken { get; set; }

        [JsonPropertyName("refresh_token")]
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        [DataMember(Name = "expires_in")]
        public string ExpiresIn { get; set; }

        [JsonPropertyName("token_type")]
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
    }

    [DataContract]
    public class User
    {
        [JsonPropertyName("created_at")]
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("issuer")]
        [DataMember(Name = "issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("user_id")]
        [DataMember(Name = "user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("identifier")]
        [DataMember(Name = "identifier")]
        public string Identifier { get; set; }
    }
}
