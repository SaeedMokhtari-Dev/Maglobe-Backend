using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Products.Detail
{
    public class ProductDetailResponse
    {
        public ProductDetailResponse()
        {
            CertificateItems = new List<CertificateItem>();
        }

        public long Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Quality { get; set; }
        public string Volume { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string DescriptionSeo { get; set; }
        public List<CertificateItem> CertificateItems { get; set; }
        public string LargePicture { get; set; }
        public string SmallPicture { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string Language { get; set; }
    }
}
