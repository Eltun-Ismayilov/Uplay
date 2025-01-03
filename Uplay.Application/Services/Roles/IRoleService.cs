using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Application.Models;
using Uplay.Application.Models.Roles;

namespace Uplay.Application.Services.Roles
{
    public interface IRoleService:IBaseService
    {
        Task<RoleGetAllResponse> GetAll();
    }
}
