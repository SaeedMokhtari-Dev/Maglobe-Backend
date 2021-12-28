
namespace Maglobe.Web.Controllers.Entities.Pages.Detail
{
    public class DynamicPageDetailResponse
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public string DescriptionSeo { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
        public string Url { get; set; } 
    }
}
