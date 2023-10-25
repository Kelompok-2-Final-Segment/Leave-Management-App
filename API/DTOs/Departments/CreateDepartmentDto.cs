using API.Models;

namespace API.DTOs.Departments
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; }
        public Guid? ManagerGuid { get; set; }

        public static implicit operator Department(CreateDepartmentDto createDepartmentDto)
        {
            return new Department{ 
                Guid = new Guid(),
                Name = createDepartmentDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

            }; 
        }
    }
}
