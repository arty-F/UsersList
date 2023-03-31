using MediatR;

namespace UsersList.UseCases.Users.GetUsers
{
    public record GetUsersQuery(GetUsersRequestDto Request) : IRequest<GetUsersResponseDto>;
}
