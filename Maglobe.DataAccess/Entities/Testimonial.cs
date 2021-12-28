using System;
using System.Collections.Generic;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Testimonial
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public long? AttachmentId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SocialNetwork { get; set; }
        public string Job { get; set; }
        public long? SmallPictureId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual Attachment SmallPicture { get; set; }
    }
}
