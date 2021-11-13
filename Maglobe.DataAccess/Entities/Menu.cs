using System;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Menu
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
