using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Detail
{
    public class TestimonialDetailValidator : AbstractValidator<TestimonialDetailRequest>
    {
        public TestimonialDetailValidator()
        {
            RuleFor(x => x.TestimonialId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
