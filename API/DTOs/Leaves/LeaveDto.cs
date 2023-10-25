using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Leaves
{
    public class LeaveDto
    {
        public Guid Guid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public StatusLevel Status { get; set; }
        public string Remarks { get; set; }

        public static explicit operator LeaveDto(Leave leave)
        {
            return new LeaveDto
            {
                Guid = leave.Guid,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Description = leave.Description,
                Status = leave.Status,
                Remarks = leave.Remarks
            };
        } 
        public static explicit operator Leave(LeaveDto leaveDto)
        {
            return new Leave
            {
                Guid = leaveDto.Guid,
                StartDate = leaveDto.StartDate,
                EndDate = leaveDto.EndDate,
                Description = leaveDto.Description,
                Status = leaveDto.Status,
                Remarks = leaveDto.Remarks
            };
        }
    }
}
