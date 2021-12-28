using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Testimonials.Get
{
    public class TestimonialGetResponse
    {
        public int TotalCount { get; set; }
        public List<TestimonialGetResponseItem> Items { get; set; }
    }
    public class TestimonialGetResponseItem
    {
        public long Key { get; set; }
        public string Title { get; set; }
        //public string Comment { get; set; }
        //public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SocialNetwork { get; set; }
        public string Job { get; set; }
    }
}
