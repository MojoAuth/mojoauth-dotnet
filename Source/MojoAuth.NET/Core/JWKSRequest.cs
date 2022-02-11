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
        [DataMember(Name = "keys")]
        public List<Key> Keys { get; set; }
    }

    [DataContract]
    public class Key
    {
        [DataMember(Name = "kty")]
        public string KeyType { get; set; }

        [DataMember(Name = "kid")]
        public string KeyId { get; set; }

        [DataMember(Name = "use")]
        public string Use { get; set; }

        [DataMember(Name = "alg")]
        public string Algorithm { get; set; }

        [DataMember(Name = "n")]
        public string N { get; set; }

        [DataMember(Name = "e")]
        public string E { get; set; }
    }
}
