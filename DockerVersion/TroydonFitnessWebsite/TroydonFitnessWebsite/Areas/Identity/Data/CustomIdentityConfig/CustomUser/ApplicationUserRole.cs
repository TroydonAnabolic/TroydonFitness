using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.CustomUser
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual TroydonFitnessWebsiteUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
