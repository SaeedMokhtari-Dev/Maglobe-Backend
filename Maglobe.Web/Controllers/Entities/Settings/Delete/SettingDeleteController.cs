using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Settings.Delete
{
    [Route(Endpoints.ApiSettingDelete)]
    [ApiExplorerSettings(GroupName = "Setting")]
    [Authorize]
    public class SettingDeleteController : ApiController<SettingDeleteRequest>
    {
        public SettingDeleteController(IApiRequestHandler<SettingDeleteRequest> handler, IValidator<SettingDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
