using System;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Agency
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Province { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
