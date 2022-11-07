using ETicaretAPI.Application.Features.Queries.Product.GetProductId;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Features.Queries.Users
{
    public class ListUsersQueryHandler : IRequestHandler<GetProductIdQueryRequest, GetProductIdQueryResponse>
    {
        public Task<GetProductIdQueryResponse> Handle(GetProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
