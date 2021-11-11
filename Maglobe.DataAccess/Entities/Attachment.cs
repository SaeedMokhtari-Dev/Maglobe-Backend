using System;
using System.Collections.Generic;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Attachment
    {
        public Attachment()
        {
            Certificates = new HashSet<Certificate>();
            ProductAttachments = new HashSet<ProductAttachment>();
            Settings = new HashSet<Setting>();
            Testimonials = new HashSet<Testimonial>();
        }

        public long Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<ProductAttachment> ProductAttachments { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
