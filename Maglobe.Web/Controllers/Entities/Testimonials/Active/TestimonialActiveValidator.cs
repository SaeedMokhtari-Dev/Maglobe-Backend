using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Active
{
    public class TestimonialActiveValidator : AbstractValidator<TestimonialActiveRequest>
    {
        public TestimonialActiveValidator()
        {
            RuleFor(x => x.TestimonialId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
