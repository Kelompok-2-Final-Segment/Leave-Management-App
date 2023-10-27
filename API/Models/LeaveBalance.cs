using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_leave_balances")]
    public class LeaveBalance : BaseEntity
    {
        [Required, Column("used_balance")]
        public int UsedBalance { get; set; }
        [Required, Column("is_available")]
        public bool IsAvailable { get; set; }
        [Required, Column("employee_guid")]
        public Guid EmployeeGuid { get; set; }
        [Required, Column("leave_type_guid")]
        public Guid LeaveTypeGuid { get; set; }
        public Employee? Employee { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
