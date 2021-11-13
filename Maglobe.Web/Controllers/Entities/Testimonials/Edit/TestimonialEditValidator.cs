using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Edit
{
    public class TestimonialEditValidator : AbstractValidator<TestimonialEditRequest>
    {
        public TestimonialEditValidator()
        {
            RuleFor(x => x.TestimonialId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
