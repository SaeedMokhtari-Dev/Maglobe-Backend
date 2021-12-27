using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Blogs.Edit
{
    public class BlogEditValidator : AbstractValidator<BlogEditRequest>
    {
        public BlogEditValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
