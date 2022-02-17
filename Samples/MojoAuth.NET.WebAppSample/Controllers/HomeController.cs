using Microsoft.AspNetCore.Mvc;
using MojoAuth.NET.WebAppSample.Models;
using System.Diagnostics;
using System.Net;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}