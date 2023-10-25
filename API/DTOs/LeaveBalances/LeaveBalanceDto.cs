using API.Models;

namespace API.DTOs.LeaveBalances
{
    public class LeaveBalanceDto
    {
        public Guid Guid { get; set; }
        public int AvailableBalance { get; set; }
        public int UsedBalance { get; set; }
        public Guid LeaveTypeGuid { get; set; }

        public static explicit operator LeaveBalanceDto(LeaveBalance leaveBalance)
        {
            return new LeaveBalanceDto
            {
                Guid = leaveBalance.Guid,
                AvailableBalance = leaveBalance.Balance,
                UsedBalance = leaveBalance.UsedBalance,
                LeaveTypeGuid = leaveBalance.LeaveTypeGuid
            };
        }

        public static implicit operator LeaveBalance(LeaveBalanceDto leaveBalanceDto)
        {
            return new LeaveBalance
            {
                Guid = leaveBalanceDto.Guid,
                Balance = leaveBalanceDto.AvailableBalance,
                UsedBalance = leaveBalanceDto.UsedBalance,
                LeaveTypeGuid = leaveBalanceDto.LeaveTypeGuid
            };
        }
    }
}
