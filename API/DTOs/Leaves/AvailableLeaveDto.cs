using API.Models;

namespace API.DTOs.Leaves
{
    public class AvailableLeaveDto
    {
        public Guid LeaveTypeGuid { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public int UsedBalance { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }

        public static AvailableLeaveDto ConvertToAvailableLeaveDto(LeaveType leaveType, LeaveBalance leaveBalance)
        {
            return new AvailableLeaveDto
            {

                LeaveTypeGuid = leaveType.Guid,
                Name = leaveType.Name,
                Balance = leaveType.Balance,
                UsedBalance = leaveBalance.UsedBalance,
                MinDuration = leaveType.MinDuration,
                MaxDuration = leaveType.MaxDuration,
            };
        }
    }

    
}
