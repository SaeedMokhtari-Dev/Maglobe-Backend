using System;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class CustomerSupportRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
