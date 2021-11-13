namespace Maglobe.Web.Controllers.Entities.Menus.Detail
{
    public class MenuDetailResponse
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
