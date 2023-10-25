using API.Models;

namespace API.DTOs.Accounts
{
    public class AccountDto
    {
        public Guid Guid { get; set; }
        public int Otp { get; set; }
        public bool IsUsed { get; set; }
        public string Password { get; set; }
        public DateTime ExpiredTime { get; set; }


        //membuat explicit operator untuk response get, create , getbyid
        public static explicit operator AccountDto(Account account)
        {
            return new AccountDto
            {
                Guid = account.Guid,
                Otp = account.OTP,
                IsUsed = account.IsUsed,
                Password = account.Password,
                ExpiredTime = account.ExpiredTime
            };
        }

        //membuat implicit operator untuk update
        public static Account ConvertToAccount(AccountDto accountDto, Account account)
        {
            account.OTP = accountDto.Otp;
            account.IsUsed = accountDto.IsUsed;
            account.Password = accountDto.Password;
            account.ExpiredTime = accountDto.ExpiredTime;
            account.ModifiedDate = DateTime.Now;
            return account;
        }
    }
}
