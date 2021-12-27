using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Blogs.Add
{
    [Route(Endpoints.ApiBlogAdd)]
    [ApiExplorerSettings(GroupName = "Blog")]
    [Authorize]
    public class BlogAddController : ApiController<BlogAddRequest>
    {
        public BlogAddController(IApiRequestHandler<BlogAddRequest> handler, IValidator<BlogAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
