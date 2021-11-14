namespace Maglobe.Web.Controllers.Entities.Certificates.Detail
{
    public class CertificateDetailResponse
    {
        public long Key { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
