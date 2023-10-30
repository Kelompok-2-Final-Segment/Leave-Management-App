using API.DTOs.Employees;
using API.DTOs.Leaves;

namespace Client.Models
{
    public class EditStatusManagerModel
    {
        public LeaveDetailManagerDto EmployeeDetail { get; set; }
        public EditLeaveDto EditLeave { get; set; }
    }
}
