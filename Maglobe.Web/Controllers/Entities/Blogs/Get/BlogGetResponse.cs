using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Blogs.Get
{
    public class BlogGetResponse
    {
        public int TotalCount { get; set; }
        public List<BlogGetResponseItem> Items { get; set; }
    }
    public class BlogGetResponseItem
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string PublishedDate { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
