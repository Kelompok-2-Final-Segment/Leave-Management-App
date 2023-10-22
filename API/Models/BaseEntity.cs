using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management_App.Models
{
    public class BaseEntity
    {
       
        [Key, Column("guid")]
        public Guid Guid { get; set; }
        [Required, Column("created_date")]
        public DateTime CreatedDate { get; set; } 
        [Required, Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
