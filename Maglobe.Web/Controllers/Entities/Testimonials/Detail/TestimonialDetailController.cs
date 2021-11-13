using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Detail
{
    [Route(Endpoints.ApiTestimonialDetail)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialDetailController : ApiController<TestimonialDetailRequest>
    {
        public TestimonialDetailController(IApiRequestHandler<TestimonialDetailRequest> handler, IValidator<TestimonialDetailRequest> validator) : base(handler, validator)
        {
        }
    }
}
