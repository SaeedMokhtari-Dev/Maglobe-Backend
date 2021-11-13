using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Settings.Edit
{
    [Route(Endpoints.ApiSettingEdit)]
    [ApiExplorerSettings(GroupName = "Setting")]
    [Authorize]
    public class SettingEditController : ApiController<SettingEditRequest>
    {
        public SettingEditController(IApiRequestHandler<SettingEditRequest> handler, IValidator<SettingEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
