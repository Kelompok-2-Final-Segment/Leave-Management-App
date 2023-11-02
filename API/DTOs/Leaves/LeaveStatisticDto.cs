using API.Models;

namespace API.DTOs.Leaves
{
    public class LeaveStatisticDto
    {
        public int TotalEmployees { get; set; }
        public int TotalDepartments { get; set; }
        public int PendingLeaves { get; set; }
        public int RejectedLeaves { get; set; }
        public int ApprovedLeaves { get; set; }


        public static LeaveStatisticDto ConvertToStatisticLeave(IEnumerable<Employee> employees, IEnumerable<Department> departments, IEnumerable<Leave> leaves)
        {

            return new LeaveStatisticDto
            {
                TotalEmployees = employees.Count(),
                TotalDepartments = departments.Count(),
                PendingLeaves = leaves.Count(l => l.Status.ToString() == "Accepted"),
                RejectedLeaves = leaves.Count(l => l.Status.ToString() == "Rejected"),
                ApprovedLeaves = leaves.Count(l => l.Status.ToString() == "Approved")
            };
        }
    }
}
