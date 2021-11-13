using FluentValidation;
using Maglobe.Core.Api.Controllers;
using Maglobe.Core.Api.Handlers;
using Maglobe.Web.Configuration.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Edit
{
    [Route(Endpoints.ApiTestimonialEdit)]
    [ApiExplorerSettings(GroupName = "Testimonial")]
    [Authorize]
    public class TestimonialEditController : ApiController<TestimonialEditRequest>
    {
        public TestimonialEditController(IApiRequestHandler<TestimonialEditRequest> handler, IValidator<TestimonialEditRequest> validator) : base(handler, validator)
        {
        }
    }
}
