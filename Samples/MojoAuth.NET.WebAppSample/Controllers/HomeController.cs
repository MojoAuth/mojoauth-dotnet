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
        private static readonly MojoAuthHttpClient MojoAuthHttpClient = new MojoAuthHttpClient("dba8bcbd-70d7-4ab4-b0d5-600b64d2884b", "<APISECERT>");

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

            return new JsonResult(sendMagicLinkResponse.Result);
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