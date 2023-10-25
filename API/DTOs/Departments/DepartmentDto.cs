using API.Models;

namespace API.DTOs.Departments
{
    public class DepartmentDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid? ManagerGuid { get; set; }

        public static explicit operator Department(DepartmentDto dto)
        {
            return new Department
            {
                Guid = dto.Guid,
                Name = dto.Name,
                ManagerGuid = dto.ManagerGuid,
            };
        }

        public static implicit operator DepartmentDto(Department department)
        {
            return new DepartmentDto
            {
                Guid = department.Guid,
                Name = department.Name,
                ManagerGuid = department.ManagerGuid,
            };
        }
    }
}
