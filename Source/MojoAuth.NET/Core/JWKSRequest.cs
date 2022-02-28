using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using MojoAuth.NET.Http;

namespace MojoAuth.NET.Core
{
    public class JWKSRequest : HttpRequest
    {
        public JWKSRequest() : base("/token/jwks", HttpMethod.Get, typeof(JWKSResponse))
        {
        }
    }

    [DataContract]
    public class JWKSResponse
    {
        [JsonPropertyName("keys")]
        [DataMember(Name = "keys")]
        public List<Key> Keys { get; set; }
    }

    [DataContract]
    public class Key
    {
        [JsonPropertyName("kty")]
        [DataMember(Name = "kty")]
        public string KeyType { get; set; }

        [JsonPropertyName("kid")]
        [DataMember(Name = "kid")]
        public string KeyId { get; set; }

        [JsonPropertyName("use")]
        [DataMember(Name = "use")]
        public string Use { get; set; }

        [JsonPropertyName("alg")]
        [DataMember(Name = "alg")]
        public string Algorithm { get; set; }

        [JsonPropertyName("n")]
        [DataMember(Name = "n")]
        public string N { get; set; }

        [JsonPropertyName("e")]
        [DataMember(Name = "e")]
        public string E { get; set; }
    }
}
