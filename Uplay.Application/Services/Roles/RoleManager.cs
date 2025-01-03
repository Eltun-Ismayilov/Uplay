using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Models.Roles;
using Uplay.Application.Services.Reviews;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Roles
{
    public class RoleManager : BaseManager, IRoleService
    {
        private readonly IRepository<Role> repository;
        public RoleManager(IMapper mapper, IRepository<Role> repository) : base(mapper)
        {
            this.repository = repository;
        }
        public async Task<RoleGetAllResponse> GetAll()
        {
            var response = new RoleGetAllResponse();

            var roles = await repository.GetAllAsync();

            foreach (var role in roles)
            {
                response.RoleDtos.Add(new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                });
            }
            return response;
        }
    }
}
