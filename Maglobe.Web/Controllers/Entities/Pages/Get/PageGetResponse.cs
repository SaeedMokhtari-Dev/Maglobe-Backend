using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Pages.Get
{
    public class PageGetResponse
    {
        public int TotalCount { get; set; }
        public List<PageGetResponseItem> Items { get; set; }
    }
    public class PageGetResponseItem
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public string DescriptionSeo { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
