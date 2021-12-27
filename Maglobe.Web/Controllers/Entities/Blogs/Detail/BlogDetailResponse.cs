namespace Maglobe.Web.Controllers.Entities.Blogs.Detail
{
    public class BlogDetailResponse
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PublishedDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
