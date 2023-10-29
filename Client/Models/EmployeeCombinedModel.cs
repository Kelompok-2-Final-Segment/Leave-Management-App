using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Leaves;

namespace Client.Models;

public class EmployeeCombinedModel
{
    public IEnumerable<LeaveDto> EmployeeLeaveList { get; set; }
    public EmployeeDetailsDto EmployeeDetail { get; set; }
}
