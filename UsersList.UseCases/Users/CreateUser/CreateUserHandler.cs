using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersList.DataAccess;
using UsersList.DataAccess.Entities;

namespace UsersList.UseCases.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly UsersListDbContext _dbContext;

        public CreateUserHandler(UsersListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await CreateUserAsync(command.Request);
            }
            catch (Exception)
            {
                //TODO Log error
                return false;
            }

            return true;
        }

        private async Task CreateUserAsync(CreateUserRequestDto request)
        {
            var departments = await _dbContext.Departments
                .Where(d => request.DepartmentIds.Contains(d.Id))
                .ToListAsync();

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Patronymic = request.Patronymic,
                Salary = request.Salary,
                Departments = departments
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
