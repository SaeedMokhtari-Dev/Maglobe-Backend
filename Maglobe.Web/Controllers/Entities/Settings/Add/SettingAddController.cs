using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Settings.Add
{
    [Route(Endpoints.ApiSettingAdd)]
    [ApiExplorerSettings(GroupName = "Setting")]
    [Authorize]
    public class SettingAddController : ApiController<SettingAddRequest>
    {
        public SettingAddController(IApiRequestHandler<SettingAddRequest> handler, IValidator<SettingAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
