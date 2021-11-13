namespace Maglobe.Web.Controllers.Entities.Testimonials.Edit
{
    public class TestimonialEditRequest
    {
        public long TestimonialId { get; set; }
        //public string Title { get; set; }
        public string Comment { get; set; }
        public string Attachment { get; set; }
        public bool AttachmentChanged { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
