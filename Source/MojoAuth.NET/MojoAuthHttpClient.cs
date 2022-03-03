using System.Threading.Tasks;
using MojoAuth.NET.Core;
using MojoAuth.NET.Http;

namespace MojoAuth.NET
{
    public class MojoAuthHttpClient : HttpClient
    {
        public MojoAuthHttpClient(string key, string secret) : base(key, secret)
        { 
        }

        protected override string GetUserAgent()
        {
            return UserAgent.GetUserAgentHeader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Response<SendMagicLinkResponse>> SendMagicLink(string email)
        {
            var sendMagicLinkRequest = new SendMagicLinkRequest(email);
            var response = await this.Execute(sendMagicLinkRequest);
            return new Response<SendMagicLinkResponse>(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public async Task<Response<AuthenticationStatusResponse>> CheckAuthenticationStatus(string stateId)
        {
            var authStatusRequest = new AuthenticationStatusRequest(stateId);
            var response = await this.Execute(authStatusRequest);
            return new Response<AuthenticationStatusResponse>(response);
        }

        public async Task<Response<EmailOtpResponse>> SendEmailOTP(string email)
        {
            var emailOtpRequest = new EmailOtpRequest(email);
            var response = await this.Execute(emailOtpRequest);
            return new Response<EmailOtpResponse>(response);
        }

        public async Task<Response<VerifyOtpResponse>> VerifyOTP(string stateId, string otp)
        {
            var verifyOtpRequest = new VerifyOtpRequest(stateId, otp);
            var response = await this.Execute(verifyOtpRequest);
            return new Response<VerifyOtpResponse>(response);
        }

        public async Task<Response<JWKSResponse>> GetJWKS()
        {
            var jwksRequest = new JWKSRequest();
            var response = await this.Execute(jwksRequest);
            return new Response<JWKSResponse>(response);
        }

        public async Task<Response<ValidateTokenResponse>> ValidateToken(string token)
        {
            var validateTokenRequest = new ValidateTokenRequest(token);
            var response = await this.Execute(validateTokenRequest);
            return new Response<ValidateTokenResponse>(response);
        }

        public async Task<Response<CheckWebAuthnResponse>> CheckWebAuthnRequest(string email)
        {
            var checkWebAuthnRequest = new CheckWebAuthnRequest(email);
            var response = await this.Execute(checkWebAuthnRequest);
            return new Response<CheckWebAuthnResponse>(response);
        }

        
    }
}
