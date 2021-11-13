using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Delete
{
    public class TestimonialDeleteValidator : AbstractValidator<TestimonialDeleteRequest>
    {
        public TestimonialDeleteValidator()
        {
            RuleFor(x => x.TestimonialId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
