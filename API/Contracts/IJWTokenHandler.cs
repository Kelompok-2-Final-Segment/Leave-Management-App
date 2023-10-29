using API.DTOs.Accounts;
using System.Security.Claims;

namespace API.Contracts
{
    public interface IJWTokenHandler
    {
        string Generate(IEnumerable<Claim> claims);
        public ClaimsDto ExtractClaimsFromJwt(string token);

    }
}
