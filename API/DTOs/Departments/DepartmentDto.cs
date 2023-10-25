using API.Models;

namespace API.DTOs.Departments
{
    public class DepartmentDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid? ManagerGuid { get; set; }

        public static Department ConvertToDepartment(DepartmentDto dto, Department department)
        {
            department.Name = dto.Name;
            department.ManagerGuid = dto.ManagerGuid;
            department.ModifiedDate = DateTime.Now;
            return department;
        }

        public static explicit operator DepartmentDto(Department department)
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
