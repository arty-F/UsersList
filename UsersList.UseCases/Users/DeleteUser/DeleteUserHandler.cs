using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersList.DataAccess;

namespace UsersList.UseCases.Users.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly UsersListDbContext _dbContext;

        public DeleteUserHandler(UsersListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await DeleteUserAsync(command.Request);
            }
            catch (Exception)
            {
                //TODO Log error
                return false;
            }

            return true;
        }

        private async Task DeleteUserAsync(DeleteUserRequestDto request)
        {
            var user = await _dbContext.Users
                .FirstAsync(u => u.Id == request.Id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
