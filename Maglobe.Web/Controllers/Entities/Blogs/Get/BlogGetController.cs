using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Get
{
    [Route(Endpoints.ApiBlogGet)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogGetController : ApiController<BlogGetRequest>
    {
        public BlogGetController(IApiRequestHandler<BlogGetRequest> handler, IValidator<BlogGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
