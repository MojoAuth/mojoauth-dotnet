//-----------------------------------------------------------------------
// <copyright file="CheckWebAuthnRequest.cs" company="MojoAuth">
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
    public class CheckWebAuthnRequest : HttpRequest
    {
        public CheckWebAuthnRequest(string email) : base($"/webauthn/check?email={email}", HttpMethod.Get, typeof(CheckWebAuthnResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new EmailOtpPayload { Email = email };
            this.Body = body;
        }
    }

    [DataContract]
    public class CheckWebAuthnResponse
    {
        [JsonPropertyName("webauthn_registered")]
        [DataMember(Name = "webauthn_registered")]
        public bool WebAuthnRegistered { get; set; }

        [JsonPropertyName("first_login")]
        [DataMember(Name = "first_login")]
        public bool FirstLogin { get; set; }
    }
}
