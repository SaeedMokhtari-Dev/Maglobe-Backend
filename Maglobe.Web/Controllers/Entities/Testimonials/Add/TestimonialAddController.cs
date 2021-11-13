using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Add
{
    [Route(Endpoints.ApiTestimonialAdd)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialAddController : ApiController<TestimonialAddRequest>
    {
        public TestimonialAddController(IApiRequestHandler<TestimonialAddRequest> handler, IValidator<TestimonialAddRequest> validator) : base(handler, validator)
        {
        }
    }
}
