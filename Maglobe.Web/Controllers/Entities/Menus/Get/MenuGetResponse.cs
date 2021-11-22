using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Menus.Get
{
    public class MenuGetResponse
    {
        public int TotalCount { get; set; }
        public List<MenuGetResponseItem> Items { get; set; }
    }
    public class MenuGetResponseItem
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
    }
}
