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
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CreatedAt { get; set; }
        public string ModifiedAt { get; set; }
        public string LastLoginAt { get; set; }
    }
}
