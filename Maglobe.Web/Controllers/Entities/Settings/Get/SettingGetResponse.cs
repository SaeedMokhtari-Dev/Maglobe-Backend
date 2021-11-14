using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Settings.Get
{
    public class SettingGetResponse
    {
        public int TotalCount { get; set; }
        public List<SettingGetResponseItem> Items { get; set; }
    }
    public class SettingGetResponseItem
    {
        public long Key { get; set; }
        //public string WebsiteLogoImage { get; set; }
        public string WebsiteTitle { get; set; }
        public string Language { get; set; }
    }
}
