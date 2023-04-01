using MediatR;
using Microsoft.EntityFrameworkCore;
using UsersList.DataAccess;
using UsersList.DataAccess.Entities;

namespace UsersList.UseCases.Users.GetUsers
{
    internal class GetUsersHandler : IRequestHandler<GetUsersQuery, GetUsersResponseDto>
    {
        private readonly UsersListDbContext _dbContext;

        public GetUsersHandler(UsersListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetUsersResponseDto> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            GetUsersResponseDto result;

            try
            {
                result = await GetUsersAsync(query.Request);
            }
            catch (Exception)
            {
                //TODO Log error
                result = new GetUsersResponseDto(new List<UserDto>());
            }

            return result;
        }

        private async Task<GetUsersResponseDto> GetUsersAsync(GetUsersRequestDto request)
        {
            var usersQuery = GetFilteredUsersQuery(request);
            var users = await usersQuery.ToListAsync();

            //TODO add automapper
            var usersDto = MapUsers(users);
            var result = new GetUsersResponseDto( usersDto);

            return result;
        }

        private IQueryable<User> GetFilteredUsersQuery(GetUsersRequestDto request)
        {
            var users = _dbContext.Users.AsQueryable();

            if (request.DepartmentIds != null && request.DepartmentIds.Count > 0)
            {
                users = users.Where(u => u.Departments.Any(d => request.DepartmentIds.Contains(d.Id)));
            }

            if (request.MinSalary != default)
            {
                users = users.Where(u => u.Salary >= request.MinSalary);
            }

            if (request.MaxSalary != default)
            {
                users = users.Where(u => u.Salary <= request.MaxSalary);
            }

            if (request.KeyWords != default)
            {
                users = users.Where(u =>
                    u.FirstName.Contains(request.KeyWords)
                    || u.LastName.Contains(request.KeyWords)
                    || u.Patronymic.Contains(request.KeyWords)
                    || u.Departments.Any(d => d.Name.Contains(request.KeyWords)));
            }

            users = users
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ThenBy(u => u.Patronymic);

            if (request.PageSize != default && request.PageNumber != default)
            {
                users = users
                    .Skip((request.PageNumber < 1 ? 0 : request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize);
            }

            return users;
        }

        private List<UserDto> MapUsers(List<User> users)
        {
            var result = new List<UserDto>(users.Count);
            foreach (var user in users)
            {
                result.Add(new UserDto(user.Id, user.FirstName, user.LastName, user.Patronymic, user.Salary, user.Departments.Count));
            }
            return result;
        }
    }
}
