using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Get
{
    [Route(Endpoints.ApiTestimonialGet)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialGetController : ApiController<TestimonialGetRequest>
    {
        public TestimonialGetController(IApiRequestHandler<TestimonialGetRequest> handler, IValidator<TestimonialGetRequest> validator) : base(handler, validator)
        {
        }
    }
}
