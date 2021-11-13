namespace Maglobe.Web.Controllers.Entities.Testimonials.Detail
{
    public class TestimonialDetailResponse
    {
        public long Key { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
