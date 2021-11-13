using Maglobe.Core.Enums;

#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class ProductAttachment
    {
        public long Id { get; set; }
        public long AttachmentId { get; set; }
        public long ProductId { get; set; }
        public AttachmentType AttachmentType { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual Product Product { get; set; }
    }
}
