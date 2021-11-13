using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Settings.Get
{
    [Route(Endpoints.ApiSettingGet)]
    [ApiExplorerSettings(GroupName = "Setting")]
    [Authorize]
    public class SettingGetController : ApiController<SettingGetRequest>
    {
        public SettingGetController(IApiRequestHandler<SettingGetRequest> handler, IValidator<SettingGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
