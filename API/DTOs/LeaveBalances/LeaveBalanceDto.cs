using API.Models;

namespace API.DTOs.LeaveBalances
{
    public class LeaveBalanceDto
    {
        public Guid Guid { get; set; }
        public bool IsAvailable { get; set; } 
        public int UsedBalance { get; set; }
        public Guid LeaveTypeGuid { get; set; }

        public static explicit operator LeaveBalanceDto(LeaveBalance leaveBalance)
        {
            return new LeaveBalanceDto
            {
                Guid = leaveBalance.Guid,
                IsAvailable = leaveBalance.IsAvailable,
                UsedBalance = leaveBalance.UsedBalance,
                LeaveTypeGuid = leaveBalance.LeaveTypeGuid
            };
        }

        public static LeaveBalance ConvertToLeaveBalance(LeaveBalanceDto leaveBalanceDto, LeaveBalance leaveBalance)
        {
            leaveBalance.UsedBalance = leaveBalanceDto.UsedBalance;
            leaveBalance.IsAvailable = leaveBalanceDto.IsAvailable;
            leaveBalance.LeaveTypeGuid = leaveBalanceDto.LeaveTypeGuid;
            leaveBalance.ModifiedDate = DateTime.Now;
            return leaveBalance;
        }
    }
}
