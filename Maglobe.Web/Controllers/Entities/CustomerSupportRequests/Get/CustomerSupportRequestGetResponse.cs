using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Get
{
    public class CustomerSupportRequestGetResponse
    {
        public int TotalCount { get; set; }
        public List<CustomerSupportRequestGetResponseItem> Items { get; set; }
    }
    public class CustomerSupportRequestGetResponseItem
    {
        public long Key { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
    }
}
