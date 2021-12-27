using FluentValidation;
using Maglobe.Core.Constants;

namespace Maglobe.Web.Controllers.Entities.Blogs.Detail
{
    public class BlogDetailValidator : AbstractValidator<BlogDetailRequest>
    {
        public BlogDetailValidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage(ApiMessages.IdRequired);
        }
    }
}
