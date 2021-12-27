using System.Collections.Generic;
using Maglobe.Web.Controllers.Entities.Products.Detail;

namespace Maglobe.Web.Services.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Quality { get; set; }
        public string Volume { get; set; }
        public string OilType { get; set; }
        public int DisplayOrder { get; set; }
        public string DescriptionSeo { get; set; }
        public List<CertificateItem> CertificateItems { get; set; }
        public string LargePicture { get; set; }
        public string SmallPicture { get; set; }
    }
}