using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Leaves
{
    public class CreateLeaveDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public Guid EmployeeGuid { get; set; }
        public Guid LeaveTypeGuid { get; set; }

        public static implicit operator Leave(CreateLeaveDto dto)
        {
            return new Leave
            {
                Guid = Guid.NewGuid(),
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Description = dto.Description,
                Status = 0,
                RemarksManager = "",
                RemarksHR = "",
                EmployeeGuid = dto.EmployeeGuid,
                LeaveTypeGuid = dto.LeaveTypeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
