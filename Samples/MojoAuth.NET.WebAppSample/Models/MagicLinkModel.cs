namespace MojoAuth.NET.WebAppSample.Models
{
    public class MagicLinkModel
    {
        public string? Email { get; set; }
    }

    public class SendMagicLinkResponse
    {
        public string? StateId { get; set; }
    }

    public class ErrorResponse
    {
        public string? Error { get; set; }
    }
}
