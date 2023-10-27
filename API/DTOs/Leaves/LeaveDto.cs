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
        public string Status { get; set; }
        public string RemarksManager { get; set; } 
        public string RemarksHR { get; set; }

        public static explicit operator LeaveDto(Leave leave)
        {
            return new LeaveDto
            {
                Guid = leave.Guid,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Description = leave.Description,
                Status = leave.Status.ToString(),
                RemarksManager = leave.RemarksManager,
                RemarksHR = leave.RemarksHR
            };
        }

    }
}
