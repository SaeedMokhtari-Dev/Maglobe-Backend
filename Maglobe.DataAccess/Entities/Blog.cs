using System;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class Blog
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public long? AttachmentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Language { get; set; }
        public long SeenCount { get; set; }

        public virtual Attachment Attachment { get; set; }
    }
}
