using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Services
{
    interface IManageRoleService
    {
        Task CreateUserRoles(IServiceProvider serviceProvider);
    }
}
