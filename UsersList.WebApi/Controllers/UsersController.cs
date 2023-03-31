using MediatR;
using Microsoft.AspNetCore.Mvc;
using UsersList.UseCases.Users.CreateUser;
using UsersList.UseCases.Users.DeleteUser;
using UsersList.UseCases.Users.GetUsers;
using UsersList.UseCases.Users.UpdateUser;

namespace UsersList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediatr;

        public UsersController(ISender mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost(nameof(CreateUser))]
        public async Task<bool> CreateUser(CreateUserRequestDto request)
        {
            var command = new CreateUserCommand(request);
            return await _mediatr.Send(command);
        }

        [HttpPost(nameof(UpdateUser))]
        public async Task<bool> UpdateUser(UpdateUserRequestDto request)
        {
            var command = new UpdateUserCommand(request);
            return await _mediatr.Send(command);
        }

        [HttpPost(nameof(DeleteUser))]
        public async Task<bool> DeleteUser(DeleteUserRequestDto request)
        {
            var command = new DeleteUserCommand(request);
            return await _mediatr.Send(command);
        }

        [HttpPost(nameof(GetUsers))]
        public async Task<GetUsersResponseDto> GetUsers(GetUsersRequestDto request)
        {
            var query = new GetUsersQuery(request);
            return await _mediatr.Send(query);
        }
    }
}