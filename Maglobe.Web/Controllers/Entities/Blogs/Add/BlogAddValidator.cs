using FluentValidation;

namespace Maglobe.Web.Controllers.Entities.Blogs.Add
{
    public class BlogAddValidator : AbstractValidator<BlogAddRequest>
    {
        public BlogAddValidator()
        {
        }
    }
}
