using UsersList.Contracts.Users;

namespace UsersList.UseCases.Users.GetUsers
{
    public record GetUsersResponseDto(
        List<UserDto> Users);
}
