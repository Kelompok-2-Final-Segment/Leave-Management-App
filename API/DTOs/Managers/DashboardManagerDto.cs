using API.DTOs.Leaves;
using API.Models;

namespace API.DTOs.Managers
{
    public class DashboardManagerDto
    {
        public int AllLeave { get; set; }
        public int PendingLeaves { get; set; }
        public int AllEmployee { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<LeaveDto>? RecentLeave { get; set; }

        public static DashboardManagerDto ConvertToDashboardManagerDto(int leavesCount, int employeesCount, int pendingLeaveCount, Department department , IEnumerable<LeaveDto> recentLeave)
        {
            return new DashboardManagerDto
            {
                AllLeave = leavesCount,
                PendingLeaves = pendingLeaveCount,
                AllEmployee = employeesCount,
                DepartmentName = department.Name,
                RecentLeave = recentLeave
            };
        }
    }
}
