using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Edit
{
    [Route(Endpoints.ApiBlogEdit)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogEditController : ApiController<BlogEditRequest>
    {
        public BlogEditController(IApiRequestHandler<BlogEditRequest> handler, IValidator<BlogEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
