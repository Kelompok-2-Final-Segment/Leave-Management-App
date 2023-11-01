using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers;
using Client.Contracts;
using Client.DTOs;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Net.Http;
using System.Text;

namespace Client.Repositories
{
    public class AccountRepository : GeneralRepository, IAccountRepository
    {
        public AccountRepository(string request = "Accounts/") : base(request)
        {
        }

        public async Task<ResponseOkHandler<ClaimsDto>> GetClaims(string Token)
        {
            ResponseOkHandler<ClaimsDto> entityVM = null;
            using (var response = httpClient.GetAsync(request + "ExtractToken/" + Token).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<ClaimsDto>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseOkHandler<TokenDto>> Login(LoginDto login)
        {
            ResponseOkHandler<TokenDto> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "Login/", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<TokenDto>>(apiResponse);
            }
            return entityVM;
        }   
        public async Task<ResponseOkHandler<string>> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            ResponseOkHandler<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(forgotPasswordDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "ForgotPassword/", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
            }
            return entityVM;
        }  
        public async Task<ResponseOkHandler<string>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            ResponseOkHandler<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordDto), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request + "ChangePassword/", content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseOkHandler<string>>(apiResponse);
            }
            return entityVM;
        }
    }
}
