namespace MojoAuth.NET
{
    /// <summary>
    /// Constants that are used by the SDK.
    /// </summary>
    public static class BaseConstants
    {
        public const string KeyAuthorizationHeader = "X-API-Key";

        /// <summary>
        /// Configuration API Secret Header Key
        /// </summary>
        public const string SecretAuthorizationHeader = "X-API-Secret";

        /// <summary>
        /// Application - Json Content Type
        /// </summary>
        public const string ContentTypeApplicationJson = "application/json";

        public const string UserAgent = "MojoAuth.NET HTTP/1.1";

        public const string BaseUrl = "https://dev-api.mojoauth.com";

        public const string Version = "0.1";
    }
}