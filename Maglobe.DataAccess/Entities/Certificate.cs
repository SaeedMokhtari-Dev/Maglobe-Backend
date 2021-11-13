using System;
using System.Collections.Generic;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Certificate
    {
        public Certificate()
        {
            ProductCertificates = new HashSet<ProductCertificate>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long? AttachmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Language { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual ICollection<ProductCertificate> ProductCertificates { get; set; }
    }
}
