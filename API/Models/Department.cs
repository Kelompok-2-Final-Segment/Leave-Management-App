using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("tb_m_departments")]
    public class Department : BaseEntity
    {
        [Required, Column("name",TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Column("manager_guid")]
        public Guid? ManagerGuid { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
    }
}
