using System;
using System.Collections.Generic;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductAttachments = new HashSet<ProductAttachment>();
            ProductCertificates = new HashSet<ProductCertificate>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Quality { get; set; }
        public string Volume { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string DescriptionSeo { get; set; }
        public string Language { get; set; }

        public virtual ICollection<ProductAttachment> ProductAttachments { get; set; }
        public virtual ICollection<ProductCertificate> ProductCertificates { get; set; }
    }
}
