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

        public static LeaveBalance ConvertToLeaveBalance(LeaveBalanceDto leaveBalanceDto, LeaveBalance leaveBalance)
        {

            leaveBalance.Balance = leaveBalanceDto.AvailableBalance;
            leaveBalance.UsedBalance = leaveBalanceDto.UsedBalance;
            leaveBalance.LeaveTypeGuid = leaveBalanceDto.LeaveTypeGuid;
            leaveBalance.ModifiedDate = DateTime.Now;
            return leaveBalance;
        }
    }
}
