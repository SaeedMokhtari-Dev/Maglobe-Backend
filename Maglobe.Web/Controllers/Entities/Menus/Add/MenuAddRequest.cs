namespace Maglobe.Web.Controllers.Entities.Menus.Add
{
    public class MenuAddRequest
    {
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
