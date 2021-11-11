using System.Collections.Generic;

namespace Maglobe.Web.Controllers.Entities.Users.Get
{
    public class UserGetResponse
    {
        public int TotalCount { get; set; }
        public List<UserGetResponseItem> Items { get; set; }
    }
    public class UserGetResponseItem
    {
        public long Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Barcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public string MotherName { get; set; }
        public string CertificateId { get; set; }
        public string NickName { get; set; }
        public bool Married { get; set; }
        public string Qualification { get; set; }
        public string SkillDescription { get; set; }
        public string FieldOfStudy { get; set; }
        public string PostalCode { get; set; }
        public string MoreDescription { get; set; }
        public string Email { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string LastLoginAt { get; set; }
        public bool IsActive { get; set; }
    }
}
