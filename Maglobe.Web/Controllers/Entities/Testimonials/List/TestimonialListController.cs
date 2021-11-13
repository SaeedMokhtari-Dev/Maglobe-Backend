using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.List
{
    [Route(Endpoints.ApiTestimonialList)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialListController : ApiController<TestimonialListRequest>
    {
        public TestimonialListController(IApiRequestHandler<TestimonialListRequest> handler, IValidator<TestimonialListRequest> validator) : base(handler, validator)
        {
        }
    }
}
