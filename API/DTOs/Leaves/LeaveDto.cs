using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Leaves
{
    public class LeaveDto
    {
        public Guid Guid { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string NIK { get; set; }
        public string LeaveName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } 

        

        public static LeaveDto ConvertToLeaveDto(Leave leave, LeaveType leaveType, Employee employee)
        {
            return new LeaveDto
            {
                Guid = leave.Guid,
                CreatedDate = leave.CreatedDate,
                FullName = string.Concat(employee.FirstName + " " + employee.LastName),
                NIK = employee.NIK,
                LeaveName = leaveType.Name,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Status = leave.Status.ToString(),
            };
        } 
        public static LeaveDto ConvertToLeaveStaff(Leave leave, LeaveType leaveType)
        {
            return new LeaveDto
            {
                Guid = leave.Guid,
                CreatedDate = leave.CreatedDate,
                LeaveName = leaveType.Name,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                Status = leave.Status.ToString(),
            };
        }

    }
}
