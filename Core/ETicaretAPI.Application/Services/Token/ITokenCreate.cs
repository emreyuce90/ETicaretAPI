using ETicaretAPI.Application.Dtos.TokenDto;

namespace ETicaretAPI.Application.Services.Token
{
    public interface ITokenCreate
    {
        TokenDto CreateToken(int minute);
    }
}
