﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    [Table("tb_m_leave_types")]
    public class LeaveType : BaseEntity
    {
        [Required, Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required, Column("min_duration")]
        public int MinDuration { get; set; }
        [Required, Column("max_duration")]
        public int MaxDuration { get; set; }
        public IEnumerable<Leave>? Leaves { get; set; }
    }
}