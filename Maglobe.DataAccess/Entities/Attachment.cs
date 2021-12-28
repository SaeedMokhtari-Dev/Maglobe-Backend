using System;
using System.Collections.Generic;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Attachment
    {
        public Attachment()
        {
            Blogs = new HashSet<Blog>();
            Certificates = new HashSet<Certificate>();
            ProductAttachments = new HashSet<ProductAttachment>();
            Settings = new HashSet<Setting>();
            TestimonialAttachments = new HashSet<Testimonial>();
            TestimonialSmallPictures = new HashSet<Testimonial>();
        }

        public long Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<ProductAttachment> ProductAttachments { get; set; }
        public virtual ICollection<Setting> Settings { get; set; }
        public virtual ICollection<Testimonial> TestimonialAttachments { get; set; }
        public virtual ICollection<Testimonial> TestimonialSmallPictures { get; set; }
    }
}
