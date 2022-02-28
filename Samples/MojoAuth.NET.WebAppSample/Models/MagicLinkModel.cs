using System.Text.Json.Serialization;

namespace MojoAuth.NET.WebAppSample.Models
{
    public class MagicLinkModel
    {
        public string? Email { get; set; }
    }

    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
