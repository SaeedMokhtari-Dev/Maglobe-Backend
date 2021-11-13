using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Certificates.Get
{
    public class CertificateGetResponse
    {
        public int TotalCount { get; set; }
        public List<CertificateGetResponseItem> Items { get; set; }
    }
    public class CertificateGetResponseItem
    {
        public long Key { get; set; }
        public string Title { get; set; }
        //public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
