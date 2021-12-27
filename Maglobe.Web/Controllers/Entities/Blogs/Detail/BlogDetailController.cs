using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Detail
{
    [Route(Endpoints.ApiBlogDetail)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogDetailController : ApiController<BlogDetailRequest>
    {
        public BlogDetailController(IApiRequestHandler<BlogDetailRequest> handler, IValidator<BlogDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
