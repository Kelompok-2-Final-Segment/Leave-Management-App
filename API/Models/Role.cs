﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{

    [Table("tb_m_roles")]
    public class Role : BaseEntity
    {     
        [Required, Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
    }

