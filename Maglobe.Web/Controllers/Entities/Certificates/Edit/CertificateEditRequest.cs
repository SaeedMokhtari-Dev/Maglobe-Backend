namespace Maglobe.Web.Controllers.Entities.Certificates.Edit
{
    public class CertificateEditRequest
    {
        public long CertificateId { get; set; }
        public string Title { get; set; }
        public string Attachment { get; set; }
        public bool AttachmentChanged { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
