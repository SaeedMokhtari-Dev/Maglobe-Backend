using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Add
{
    public class TestimonialAddValidator : AbstractValidator<TestimonialAddRequest>
    {
        public TestimonialAddValidator()
        {
        }
    }
}
