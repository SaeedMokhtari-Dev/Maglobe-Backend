using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Delete
{
    [Route(Endpoints.ApiBlogDelete)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogDeleteController : ApiController<BlogDeleteRequest>
    {
        public BlogDeleteController(IApiRequestHandler<BlogDeleteRequest> handler, IValidator<BlogDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
