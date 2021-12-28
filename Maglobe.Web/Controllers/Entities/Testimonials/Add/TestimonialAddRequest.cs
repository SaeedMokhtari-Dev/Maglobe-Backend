namespace Maglobe.Web.Controllers.Entities.Testimonials.Add
{
    public class TestimonialAddRequest
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SocialNetwork { get; set; }
        public string Job { get; set; }
        public string SmallPicture { get; set; }
    }
}
