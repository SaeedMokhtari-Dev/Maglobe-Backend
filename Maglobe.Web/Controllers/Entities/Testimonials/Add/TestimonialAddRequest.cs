namespace Maglobe.Web.Controllers.Entities.Testimonials.Add
{
    public class TestimonialAddRequest
    {
        public string Comment { get; set; }
        public string Attachment { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
