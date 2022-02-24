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

        public async Task<Response<SendMagicLinkResponse>> SendMagicLink(string email)
        {
            var sendMagicLinkRequest = new SendMagicLinkRequest(email);
            var response = await this.Execute(sendMagicLinkRequest);
            return new Response<SendMagicLinkResponse>(response);
        }


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

        public async Task<Response<RegistrationWebAuthnInitializeResponse>> RegistrationWebAuthnInitialize(string token)
        {
            var registrationWebAuthnInitialize = new RegistrationWebAuthnInitialize(token);
            var response = await this.Execute(registrationWebAuthnInitialize);
            return new Response<RegistrationWebAuthnInitializeResponse>(response);
        }
        
        public async Task<Response<RegistrationWebAuthnFinishResponse>> RegistrationWebAuthnFinish(string stateId,string id,string rawId,string type,string attestationObject,string clientDataJSON)
        {
            var registrationWebAuthnFinish = new RegistrationWebAuthnFinish(stateId,id,rawId,type,attestationObject,clientDataJSON);
            var response = await this.Execute(registrationWebAuthnFinish);
            return new Response<RegistrationWebAuthnFinishResponse>(response);
        }

        public async Task<Response<LoginWebAuthnInitializeResponse>> LoginWebAuthnInitialize(string email)
        {
            var loginWebAuthnInitialize = new LoginWebAuthnInitialize(email);
            var response = await this.Execute(loginWebAuthnInitialize);
            return new Response<LoginWebAuthnInitializeResponse>(response);
        }

        public async Task<Response<LoginWebAuthnFinishResponse>> LoginWebAuthnFinish(string stateId,string email,string id,string rawId,string type,string txAuthSimple)
        {
            var loginWebAuthnFinish = new LoginWebAuthnFinish(stateId,email,id,rawId,type,txAuthSimple);
            var response = await this.Execute(loginWebAuthnFinish);
            return new Response<LoginWebAuthnFinishResponse>(response);
        }

        public async Task<Response<CheckWebAuthnResponse>> CheckWebAuthnRequest(string email)
        {
            var checkWebAuthnRequest = new CheckWebAuthnRequest(email);
            var response = await this.Execute(checkWebAuthnRequest);
            return new Response<CheckWebAuthnResponse>(response);
        }

        
    }
}
