#nullable disable

namespace Maglobe.DataAccess.Entities
{
    public partial class ProductCertificate
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public long CertificateId { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Product Product { get; set; }
    }
}
