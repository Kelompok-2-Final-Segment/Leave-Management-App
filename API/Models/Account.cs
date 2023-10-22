using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Leave_Management_App.Models
{
    [Table("tb_m_accounts")]
    public class Account : BaseEntity
    {
        [Required, Column("password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }
        [Required, Column("otp")]
        public int OTP { get; set; }
        [Required, Column("is_used")]
        public bool IsUsed { get; set; }
        [Required, Column("expired_time")]
        public DateTime ExpiredTime { get; set; }
        public ICollection<AccountRole>? AccountRoles { get; set; }

    }
}
