using Microsoft.AspNetCore.Mvc;
using MojoAuth.NET.WebAppSample.Models;
using System.Diagnostics;
using System.Net;

namespace MojoAuth.NET.WebAppSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly MojoAuthHttpClient _mojoAuthHttpClient;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _mojoAuthHttpClient = new MojoAuthHttpClient(_config["MojoAuth_Key"], _config["MojoAuth_Secret"]);
        }

        public IActionResult Index()
        {
            ViewBag.MojoAuthKey = _config["MojoAuth_Key"];
            ViewBag.MojoAuthRedirectUri = _config["MojoAuth_RedirectUri"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SendMagicLink([FromBody] MagicLinkModel magicLinkModel)
        {
            var sendMagicLinkResponse = await _mojoAuthHttpClient.SendMagicLink(magicLinkModel.Email);
            
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
            var authenticationStatus = await _mojoAuthHttpClient.CheckAuthenticationStatus(stateId);
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
            var checkWebAuthnRequest = await _mojoAuthHttpClient.CheckWebAuthnRequest(email);
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