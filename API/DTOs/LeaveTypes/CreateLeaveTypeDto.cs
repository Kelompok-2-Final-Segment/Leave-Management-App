using API.Models;

namespace API.DTOs.LeaveTypes
{
    public class CreateLeaveTypeDto
    {
        public string Name { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }

        public static implicit operator LeaveType(CreateLeaveTypeDto dto)
        {
            return new LeaveType
            {
                Guid = new Guid(),
                Name = dto.Name,
                MinDuration = dto.MinDuration,
                MaxDuration = dto.MaxDuration,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}
