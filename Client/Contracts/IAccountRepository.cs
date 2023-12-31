﻿using API.DTOs.Accounts;
using API.Utilities.Handlers;
using Client.DTOs;

namespace Client.Contracts
{
    public interface IAccountRepository
    {
        public Task<ResponseOkHandler<TokenDto>> Login(LoginDto login);
        public Task<ResponseOkHandler<ClaimsDto>> GetClaims(string Token);
        public Task<ResponseOkHandler<string>> ForgotPassword(ForgotPasswordDto forgotPasswordDto);
        public Task<ResponseOkHandler<string>> ChangePassword(ChangePasswordDto changePasswordDto);
    }
}
