namespace Maglobe.Web.Controllers.Entities.Pages.Add
{
    public class DynamicPageAddRequest
    {
        public string Title { get; set; }
        public string DescriptionSeo { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
