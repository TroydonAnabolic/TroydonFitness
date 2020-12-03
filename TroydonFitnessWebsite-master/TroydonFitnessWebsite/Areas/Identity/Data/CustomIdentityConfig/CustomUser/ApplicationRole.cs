using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.CustomUser
{
    public class ApplicationRole : IdentityRole
    {
        //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
        public ApplicationRole()
        {
        }
    }
}
