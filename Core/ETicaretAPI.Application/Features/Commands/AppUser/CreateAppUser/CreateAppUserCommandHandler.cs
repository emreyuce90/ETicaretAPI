using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.AppUser> _userManager;

        public CreateAppUserCommandHandler(UserManager<Domain.Entities.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.AppUser user = new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                UserName = request.Username,
                Id=Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            CreateAppUserCommandResponse response = new() { IsSucceded = true};
            if (result.Succeeded)
            {
                response.Message = "Kullanıcı ekleme işlemi başarılı";
            }
            else
            {
                response.IsSucceded = false;
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code}-{error.Description}";
                }
            }
            return response;
            
        }
    }
}
