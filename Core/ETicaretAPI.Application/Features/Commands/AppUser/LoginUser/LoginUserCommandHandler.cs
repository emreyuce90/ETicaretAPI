using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.AppUser> _signInManager;
        public LoginUserCommandHandler(UserManager<Domain.Entities.AppUser> userManager, SignInManager<Domain.Entities.AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            //User ı kontrol et
            var user = await _userManager.FindByNameAsync(request.Username);
            if(user == null)
            {
                user = await _userManager.FindByEmailAsync(request.Username);
            }

            if(user == null)
            {
                throw new Exception("Kullanıcı adı veya şifre hatalı");
            }
            //şifreyi kontrol et
            var result =await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded)
            {

            }
            return new();
        }
    }
}
