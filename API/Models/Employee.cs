using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using API.Utilities.Enums;

namespace API.Models
{
    [Table("tb_m_employees")]
    public class Employee : BaseEntity
    {

        [Required, Column("first_name", TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }

        [Required, Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required, Column("hiring_date")]
        public DateTime HiringDate { get; set; }
        [Required, Column("gender")]
        public Gender Gender { get; set; }

        [Required, Column("email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required, Column("phone_number", TypeName = "nvarchar(25)")]
        public string PhoneNumber { get; set; }
        [Required,Column("department_guid")]
        public Guid DepartmentGuid { get; set; }
        public Account? Account { get; set; }
        public Department? Department { get; set; }
        public LeaveBalance? LeaveBalance { get; set; }
        public IEnumerable<Leave>? Leaves { get; set; }        

    }
}