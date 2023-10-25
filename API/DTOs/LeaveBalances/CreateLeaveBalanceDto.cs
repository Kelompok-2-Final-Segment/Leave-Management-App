using API.Models;

namespace API.DTOs.LeaveBalances
{
    public class CreateLeaveBalanceDto
    {
        public int Balance { get; set; }
        public int UsedBalance { get; set; }
        public Guid LeaveTypeGuid { get; set; }

        public static implicit operator LeaveBalance(CreateLeaveBalanceDto createLeaveBalanceDto)
        {
            return new LeaveBalance
            {
                Guid = new Guid(),
                Balance = createLeaveBalanceDto.Balance,
                UsedBalance = createLeaveBalanceDto.UsedBalance,
                LeaveTypeGuid = createLeaveBalanceDto.LeaveTypeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}
