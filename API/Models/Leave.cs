using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("tb_m_leaves")]
    public class Leave : BaseEntity
    {
        [Required, Column("start_date")]
        public DateTime StartDate { get; set; }
        [Required, Column("end_date")]
        public DateTime EndDate { get; set; }
        [Required, Column("description", TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        [Required, Column("status")]
        public StatusLevel Status { get; set; }
        [Required, Column("remarks_by_manager", TypeName = "nvarchar(max)")]
        public string RemarksManager { get; set; }
        [Required, Column("remarks_by_HR", TypeName = "nvarchar(max)")]
        public string RemarksHR { get; set; }
        [Required, Column("employee_guid")]
        public Guid EmployeeGuid { get; set; }
        [Required, Column("leave_type_guid")]
        public Guid LeaveTypeGuid { get; set; }
        public Employee? Employee { get; set; }
        public LeaveType? LeaveType { get; set; }
    }
}
