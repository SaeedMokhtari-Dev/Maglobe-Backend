namespace Maglobe.Web.Controllers.Entities.Certificates.Add
{
    public class CertificateAddRequest
    {
        public string Title { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public string Language { get; set; }
    }
}
