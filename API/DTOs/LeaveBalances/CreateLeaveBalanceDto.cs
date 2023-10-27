using API.Models;

namespace API.DTOs.LeaveBalances
{
    public class CreateLeaveBalanceDto
    {

        public int UsedBalance { get; set; }
        public bool IsAvailable { get; set; }
        public Guid LeaveTypeGuid { get; set; }

        public static implicit operator LeaveBalance(CreateLeaveBalanceDto createLeaveBalanceDto)
        {
            return new LeaveBalance
            {
                Guid = new Guid(),
                UsedBalance = createLeaveBalanceDto.UsedBalance,
                IsAvailable = createLeaveBalanceDto.IsAvailable,
                LeaveTypeGuid = createLeaveBalanceDto.LeaveTypeGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };
        }
    }
}
