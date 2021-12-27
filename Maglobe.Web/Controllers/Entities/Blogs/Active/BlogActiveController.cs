using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Active
{
    [Route(Endpoints.ApiBlogActive)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogActiveController : ApiController<BlogActiveRequest>
    {
        public BlogActiveController(IApiRequestHandler<BlogActiveRequest> handler, IValidator<BlogActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
