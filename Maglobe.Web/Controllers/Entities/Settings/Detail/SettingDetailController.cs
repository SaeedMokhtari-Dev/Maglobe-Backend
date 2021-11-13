using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Settings.Detail
{
    [Route(Endpoints.ApiSettingDetail)]
    [ApiExplorerSettings(GroupName = "Setting")]
    [Authorize]
    public class SettingDetailController : ApiController<SettingDetailRequest>
    {
        public SettingDetailController(IApiRequestHandler<SettingDetailRequest> handler, IValidator<SettingDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
