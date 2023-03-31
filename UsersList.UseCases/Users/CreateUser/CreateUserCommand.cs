using MediatR;

namespace UsersList.UseCases.Users.CreateUser
{
    public record CreateUserCommand(CreateUserRequestDto Request) : IRequest<bool>;
}
