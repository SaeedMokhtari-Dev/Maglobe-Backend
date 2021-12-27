using FluentValidation;

namespace Maglobe.Web.Controllers.Entities.Blogs.List
{
    public class BlogListValidator : AbstractValidator<BlogListRequest>
    {
        public BlogListValidator()
        {
        }
    }
}
