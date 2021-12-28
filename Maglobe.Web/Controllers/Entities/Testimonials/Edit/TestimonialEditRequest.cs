namespace Maglobe.Web.Controllers.Entities.Testimonials.Edit
{
    public class TestimonialEditRequest
    {
        public long TestimonialId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public bool PictureChanged { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SocialNetwork { get; set; }
        public string Job { get; set; }
        public string SmallPicture { get; set; }
        public bool SmallPictureChanged { get; set; }
    }
}
