using API.DTOs.Roles;
using API.Models;

namespace API.Contracts
{
    public interface IRoleRepository : IGeneralRepository<Role>
    {
        Guid? GetRoleGuid(string roleName);
    }
}
