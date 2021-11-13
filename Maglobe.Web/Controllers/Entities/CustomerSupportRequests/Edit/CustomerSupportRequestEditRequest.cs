namespace Maglobe.Web.Controllers.Entities.CustomerSupportRequests.Edit
{
    public class CustomerSupportRequestEditRequest
    {
        public long CustomerSupportRequestId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
    }
}
