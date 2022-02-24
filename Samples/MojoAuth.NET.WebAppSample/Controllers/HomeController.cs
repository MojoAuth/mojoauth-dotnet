using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MojoAuth.NET.WebAppSample.Models;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace MojoAuth.NET.WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly MojoAuthHttpClient MojoAuthHttpClient = new MojoAuthHttpClient("77c08f48-63fa-4d12-8dcd-b87b12834408", "c82fb996tljk7bmhrohg.f8RLj4tqcoFoBSqizfH6ik");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SendMagicLink([FromBody] MagicLinkModel magicLinkModel)
        {
            var sendMagicLinkResponse = await MojoAuthHttpClient.SendMagicLink(magicLinkModel.Email);
            
            if (sendMagicLinkResponse.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = sendMagicLinkResponse.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            } 
            
            var jsonResponse = new SendMagicLinkResponse 
            {
                StateId = sendMagicLinkResponse.Result.StateId
            };

            return new JsonResult(jsonResponse);
        }

        [HttpGet]
        public async Task<JsonResult> ValidateStateId([FromQuery] string stateId)
        {
            var authenticationStatus = await MojoAuthHttpClient.CheckAuthenticationStatus(stateId);
            if (authenticationStatus.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = authenticationStatus.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(authenticationStatus.Result);
        }

       [HttpGet]
        public async Task<JsonResult> RegistrationWebAuthnInitialize([FromQuery] string token)
        {
            var registrationWebAuthnInitialize = await MojoAuthHttpClient.RegistrationWebAuthnInitialize(token);
            if (registrationWebAuthnInitialize.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = registrationWebAuthnInitialize.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(registrationWebAuthnInitialize.Result);
        }

        [HttpPost]
        public async Task<JsonResult> RegistrationWebAuthnFinish([FromBody] string stateId,string id,string rawId,string type,string attestationObject,string clientDataJSON)
        {
            var registrationWebAuthnFinish = await MojoAuthHttpClient.RegistrationWebAuthnFinish(stateId,id,rawId,type,attestationObject,clientDataJSON);
            if (registrationWebAuthnFinish.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = registrationWebAuthnFinish.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(registrationWebAuthnFinish.Result);
        }

       [HttpGet]
        public async Task<JsonResult> LoginWebAuthnInitialize([FromQuery] string email)
        {
            var loginWebAuthnInitialize = await MojoAuthHttpClient.LoginWebAuthnInitialize(email);
            if (loginWebAuthnInitialize.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = loginWebAuthnInitialize.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(loginWebAuthnInitialize.Result);
        }

        [HttpPost]
        public async Task<JsonResult> LoginWebAuthnFinish([FromBody] string stateId,string email,string id,string rawId,string type,string txAuthSimple)
        {
            var loginWebAuthnFinish = await MojoAuthHttpClient.LoginWebAuthnFinish(stateId,email,id,rawId,type,txAuthSimple);
            if (loginWebAuthnFinish.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = loginWebAuthnFinish.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(loginWebAuthnFinish.Result);
        }

       [HttpGet]
        public async Task<JsonResult> CheckWebAuthnRequest([FromQuery] string email)
        {
            var checkWebAuthnRequest = await MojoAuthHttpClient.CheckWebAuthnRequest(email);
            if (checkWebAuthnRequest.Error != null)
            {
                var errorResponse = new ErrorResponse
                {
                    Error = checkWebAuthnRequest.Error.Description
                };
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return new JsonResult(errorResponse);
            }

            return new JsonResult(checkWebAuthnRequest.Result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}