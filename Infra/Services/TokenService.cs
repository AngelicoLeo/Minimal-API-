using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CalendarApp.Domain.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CalendarApp.Infra.Services;

public static class TokenService
{
    public static string GenerateToken(User user, byte[] key)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor 
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            }),

            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public static JwtBearerOptions GetAuthenticationOptions(byte[] key)
    {
        return new JwtBearerOptions
        {
            RequireHttpsMetadata = false,
            SaveToken = true,
            TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            }
        };
        
    }
}
