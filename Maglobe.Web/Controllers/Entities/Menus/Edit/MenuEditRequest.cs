namespace Maglobe.Web.Controllers.Entities.Menus.Edit
{
    public class MenuEditRequest
    {
        public long MenuId { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
    }
}
