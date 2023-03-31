using MediatR;

namespace UsersList.UseCases.Users.DeleteUser
{
    public record DeleteUserCommand(DeleteUserRequestDto Request) : IRequest<bool>;
}
