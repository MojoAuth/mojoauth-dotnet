//-----------------------------------------------------------------------
// <copyright file="EmailOtpRequest.cs" company="MojoAuth">
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
    public class EmailOtpRequest : HttpRequest
    {
        public EmailOtpRequest(string email) : base("/users/emailotp", HttpMethod.Post, typeof(EmailOtpResponse))
        {
            this.ContentType = BaseConstants.ContentTypeApplicationJson;
            var body = new EmailOtpPayload { Email = email };
            this.Body = body;
        }
    }

    [DataContract]
    public class EmailOtpPayload
    {
        [JsonPropertyName("email")]
        [DataMember(Name = "email")]
        public string Email;
    }

    [DataContract]
    public class EmailOtpResponse
    {
        [JsonPropertyName("state_id")]
        [DataMember(Name = "state_id")]
        public string StateId { get; set; }
    }
}
