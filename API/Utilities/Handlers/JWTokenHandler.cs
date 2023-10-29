using API.Contracts;
using API.DTOs.Accounts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utilities.Handlers
{
    public class JWTokenHandler : IJWTokenHandler
    {
        private readonly IConfiguration _configuration;
        public JWTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //membutat method untuk generate token jwt 
        public string Generate(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTService:SecretKey"]));
            var signingCredentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256);
            var tokenOpts = new JwtSecurityToken(
                issuer: _configuration["JWTService:Issuer"],
                audience: _configuration["JWTService:Audience"],
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signingCredentials,
                claims: claims
                );
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(tokenOpts);
            return encodedToken;
        }

        public ClaimsDto ExtractClaimsFromJwt(string token)
        {
            if (token == null) return new ClaimsDto(); // If the JWT token is empty, return an empty dictionary

            try
            {
                // Configure the token validation parameters
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = _configuration["JWTService:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWTService:Issuer"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTService:SecretKey"]))
                };

                // Parse and validate the JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                // Extract the claims from the JWT token
                if (securityToken != null && claimsPrincipal.Identity is ClaimsIdentity identity)
                {
                    var claims = new ClaimsDto
                    {
                        NameIdentifier = identity.FindFirst(ClaimTypes.NameIdentifier)!.Value,
                        Name = identity.FindFirst(ClaimTypes.Name)!.Value,
                        Email = identity.FindFirst(ClaimTypes.Email)!.Value
                    };

                    var roles = identity.Claims.Where(c => c.Type == ClaimTypes.Role).Select(claim => claim.Value).ToList();
                    claims.Role = roles;

                    return claims;
                }
            }
            catch
            {
                // If an error occurs while parsing the JWT token, return an empty dictionary
                return new ClaimsDto();
            }

            return new ClaimsDto();
        }
    }
}
