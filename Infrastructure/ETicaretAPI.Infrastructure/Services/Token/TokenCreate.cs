using ETicaretAPI.Application.Dtos.TokenDto;
using ETicaretAPI.Application.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ETicaretAPI.Infrastructure.Services.Token
{
    public class TokenCreate : ITokenCreate
    {
        private readonly IConfiguration _configuration;

        public TokenCreate(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateToken(int minute)
        {
            TokenDto token = new TokenDto();
            token.LifeTime = DateTime.UtcNow.AddMinutes(minute);

            //Gizli şifremizi symmetriğini alalım
            SymmetricSecurityKey symmetric = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Bu keyi şimdi şifreleyelim
            SigningCredentials credentials = new SigningCredentials(symmetric,SecurityAlgorithms.HmacSha256);

            //Token ayarlarımızı verelim
            JwtSecurityToken securityToken = new(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                notBefore:DateTime.UtcNow,
                signingCredentials:credentials
                );
            //Token oluşturalım
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken=tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
