#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Setting
    {
        public long Id { get; set; }
        public long WebsiteLogoId { get; set; }
        public string WebsiteTitle { get; set; }

        public virtual Attachment WebsiteLogo { get; set; }
    }
}
