using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.List
{
    [Route(Endpoints.ApiBlogList)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogListController : ApiController<BlogListRequest>
    {
        public BlogListController(IApiRequestHandler<BlogListRequest> handler, IValidator<BlogListRequest> validator) : base(handler, validator)
        {
        }
    }
}
