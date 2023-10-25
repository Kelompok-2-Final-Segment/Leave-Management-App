using API.Models;

namespace API.DTOs.Roles
{
    public class RoleDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }


        //membuat implicit operator untuk update
        public static Role ConvertToRole(RoleDto roleDto , Role role)
        {

            role.Name = roleDto.Name;
            role.ModifiedDate = DateTime.Now;

            return role;
        }
        //membuat explicit operator untuk response get, create , getbyid
        public static explicit operator RoleDto(Role role)
        {
            return new RoleDto
            {
                Guid = role.Guid,
                Name = role.Name,

            };
        }
    }
}
