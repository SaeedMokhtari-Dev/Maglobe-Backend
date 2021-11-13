namespace Maglobe.Web.Controllers.Entities.Products.Add
{
    public class ProductAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Quality { get; set; }
        public string Volume { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public string DescriptionSeo { get; set; }
        public long[] ProductCertificateIds { get; set; }
        public string LargePicture { get; set; }
        public string SmallPicture { get; set; }
        public string Language { get; set; }
    }
}
