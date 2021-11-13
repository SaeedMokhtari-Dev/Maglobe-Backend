using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Delete
{
    [Route(Endpoints.ApiTestimonialDelete)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialDeleteController : ApiController<TestimonialDeleteRequest>
    {
        public TestimonialDeleteController(IApiRequestHandler<TestimonialDeleteRequest> handler, IValidator<TestimonialDeleteRequest> validator) : base(handler, validator)
        {
        }
    }
}
