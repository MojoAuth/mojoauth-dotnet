using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class ValidateTokenRequest : HttpRequest
    {
        public ValidateTokenRequest(string token) : base("/token/verify", HttpMethod.Post, typeof(ValidateTokenResponse))
        {
            this.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    [DataContract]
    public class ValidateTokenResponse
    {
        [JsonPropertyName("isValid")]
        [DataMember(Name = "isValid")]
        public bool IsValid { get; set; }

        [JsonPropertyName("access_token")]
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("user")]
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
