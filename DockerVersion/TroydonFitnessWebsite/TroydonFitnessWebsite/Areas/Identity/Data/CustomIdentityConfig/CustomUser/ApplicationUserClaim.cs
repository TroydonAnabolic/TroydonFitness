﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.CustomUser
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
    public virtual TroydonFitnessWebsiteUser User { get; set; }
    }
}
