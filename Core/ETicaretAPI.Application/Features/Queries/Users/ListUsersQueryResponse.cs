using ETicaretAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Queries.Users
{
    public class ListUsersQueryResponse
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

    }
}
