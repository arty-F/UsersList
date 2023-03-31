using MediatR;

namespace UsersList.UseCases.Users.UpdateUser
{
    public record UpdateUserCommand(UpdateUserRequestDto Request) : IRequest<bool>;
}
