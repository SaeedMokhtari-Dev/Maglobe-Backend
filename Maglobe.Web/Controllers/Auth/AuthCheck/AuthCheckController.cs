using Maglobe.Core.Api.Models;
using Maglobe.Core.Constants;
using Maglobe.Core.Interfaces;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Auth.AuthCheck
{
    [Authorize(Policy = nameof(Policies.ActiveUser))]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class AuthCheckController: ControllerBase, IApiController
    {

        [HttpGet]
        [Route(Endpoints.ApiAuthCheck)]
        public IActionResult AuthCheck()
        {
            return ApiResponse.Ok();
        }
    }
}
