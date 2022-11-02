using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateAppUserCommandRequest:IRequest<CreateAppUserCommandResponse>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
