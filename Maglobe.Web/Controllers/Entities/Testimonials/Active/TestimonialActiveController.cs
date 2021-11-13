using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Active
{
    [Route(Endpoints.ApiTestimonialActive)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialActiveController : ApiController<TestimonialActiveRequest>
    {
        public TestimonialActiveController(IApiRequestHandler<TestimonialActiveRequest> handler, IValidator<TestimonialActiveRequest> validator) : base(handler, validator)
        {
        }
    }
}
