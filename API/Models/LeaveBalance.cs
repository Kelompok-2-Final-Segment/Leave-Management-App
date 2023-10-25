using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_leave_balances")]
    public class LeaveBalance : BaseEntity
    {
        [Required, Column("balance")]
        public int Balance { get; set; }
        [Required, Column("used_balance")]
        public int UsedBalance { get; set; }
        [Required, Column("leave_type_guid")]
        public Guid LeaveTypeGuid { get; set; }
        public Employee? Employee { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
