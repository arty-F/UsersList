using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersList.DataAccess;

namespace UsersList.UseCases.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly UsersListDbContext _dbContext;

        public UpdateUserHandler(UsersListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                await UpdateUserAsync(command.Request);
            }
            catch (Exception)
            {
                //TODO Log error
                return false;
            }

            return true;
        }

        private async Task UpdateUserAsync(UpdateUserRequestDto request)
        {
            var user = await _dbContext.Users
                .FirstAsync(u => u.Id == request.Id);

            if (request.DepartmentIds != null && request.DepartmentIds.Count > 0)
            {
                var departments = await _dbContext.Departments
                .Where(d => request.DepartmentIds.Contains(d.Id))
                .ToListAsync();

                user.Departments = departments;
            }

            if (request.FirstName != default && request.FirstName != user.FirstName)
            {
                user.FirstName = request.FirstName;
            }

            if (request.LastName != default && request.LastName != user.LastName)
            {
                user.LastName = request.LastName;
            }

            if (request.Patronymic != default && request.Patronymic != user.Patronymic)
            {
                user.Patronymic = request.Patronymic;
            }

            if (request.Salary != default && request.Salary != user.Salary)
            {
                user.Salary = request.Salary;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
