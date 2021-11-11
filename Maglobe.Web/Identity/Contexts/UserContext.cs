using System.Collections.Generic;
using Maglobe.Core.Interfaces;
using Maglobe.DataAccess.Entities;

namespace Maglobe.Web.Identity.Contexts
{
    public class UserContext: IScoped
    {
        public long Id { get; set; }

        public bool IsAuthenticated { get; set; }

        public List<UserRole> Roles { get; set; }

        public bool IsActive { get; set; }
    }
}
