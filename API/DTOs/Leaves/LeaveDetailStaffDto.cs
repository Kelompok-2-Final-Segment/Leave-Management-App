using API.Models;

namespace API.DTOs.Leaves
{
    public class LeaveDetailStaffDto
    {
        public Guid Guid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string? Document { get; set; }
        public string Status { get; set; }
        public string RemarksManager { get; set; }
        public string RemarksHR { get; set; }
        public DateTime CreatedAt { get; set; }

        public static explicit operator LeaveDetailStaffDto(Leave leave)
        {
            return new LeaveDetailStaffDto
            {
                Guid = leave.Guid,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Description = leave.Description,
                Document = leave.Document,
                Status = leave.Status.ToString(),
                RemarksManager = leave.RemarksManager,
                RemarksHR = leave.RemarksHR,
                CreatedAt = leave.CreatedDate
            };
        }
    }
}
