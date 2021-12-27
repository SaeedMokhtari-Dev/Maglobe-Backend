namespace Maglobe.Web.Controllers.Entities.Blogs.Edit
{
    public class BlogEditRequest
    {
        public long BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool PictureChanged { get; set; }
        public string PublishedDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
