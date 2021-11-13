namespace Maglobe.Web.Controllers.Entities.Settings.Edit
{
    public class SettingEditRequest
    {
        public long SettingId { get; set; }
        public string WebsiteLogo { get; set; }
        public bool WebsiteLogoChanged { get; set; }
        public string WebsiteTitle { get; set; }
        public string Language { get; set; }
    }
}
