using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.DynamicPages.Get
{
    public class DynamicPageGetResponse
    {
        public int TotalCount { get; set; }
        public List<DynamicPageGetResponseItem> Items { get; set; }
    }
    public class DynamicPageGetResponseItem
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
