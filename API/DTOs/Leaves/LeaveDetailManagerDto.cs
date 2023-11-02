using API.Models;

namespace API.DTOs.Leaves
{
    public class LeaveDetailManagerDto
    {
        public Guid? ManagerGuid { get; set; }
        public Guid LeaveGuid { get; set; }
        public string NIK { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LeaveName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveStatus { get; set; }
        public string Description { get; set; }
        public string RemarkManager { get; set; }
        public string RemarkAdmin { get; set; }
        public static LeaveDetailManagerDto ConvertToLeaveDetailManagerDto(Leave leave, LeaveType leaveType, Department department, Employee employee)
        {
            return new LeaveDetailManagerDto
            {
                ManagerGuid = department.ManagerGuid,
                LeaveGuid = leave.Guid,
                NIK = employee.NIK,
                FullName = string.Concat(employee.FirstName + " " + employee.LastName),
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                DepartmentName = department.Name,
                CreatedDate = leave.CreatedDate,
                LeaveName = leaveType.Name,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                LeaveStatus = leave.Status.ToString(),
                Description = leave.Description,
                RemarkManager = leave.RemarksManager,
                RemarkAdmin = leave.RemarksHR
            };
        }
    }
}
