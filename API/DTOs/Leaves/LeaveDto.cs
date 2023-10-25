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
        public static Leave ConvertToLeave(LeaveDto leaveDto, Leave leave)
        {
            leave.StartDate = leaveDto.StartDate;
            leave.EndDate = leaveDto.EndDate;
            leave.Description = leaveDto.Description;
            leave.Status = leaveDto.Status;
            leave.Remarks = leaveDto.Remarks;
            leave.ModifiedDate = DateTime.Now;
            return leave;
        }
    }
}
