using UsersList.Contracts.Entities;

namespace UsersList.DataAccess.Initializers
{
    public class UsersListDbInitializer
    {
        public List<User> Users { get; private set; } = null!;
        public List<Department> Departments { get; private set; } = null!;

        public UsersListDbInitializer()
        {
            Initialize();
        }

        private void Initialize()
        {
            Departments = new List<Department>(5);
            var finDep = new Department { Id = Guid.NewGuid(), Name = "Финансовый", ParentId = null };
            Departments.Add(finDep);
            var logDep = new Department { Id = Guid.NewGuid(), Name = "Логистики", ParentId = finDep.Id };
            Departments.Add(logDep);
            var buyDep = new Department { Id = Guid.NewGuid(), Name = "Закупок", ParentId = finDep.Id };
            Departments.Add(buyDep);
            var hrDep = new Department { Id = Guid.NewGuid(), Name = "Кадров", ParentId = finDep.Id };
            Departments.Add(hrDep);
            var entDep = new Department { Id = Guid.NewGuid(), Name = "Развлечений", ParentId = null };
            Departments.Add(entDep);

            Users = new List<User>(5);
            var anton = new User
            {
                Id = Guid.NewGuid(),
                LastName = "Антонов",
                FirstName = "Антон",
                Patronymic = "Антонович",
                Salary = 123m
            };
            Users.Add(anton);
            var boris = new User
            {
                Id = Guid.NewGuid(),
                LastName = "Борисов",
                FirstName = "Борис",
                Patronymic = "Борисович",
                Salary = 125.5m
            };
            Users.Add(boris);
            var vladimir = new User
            {
                Id = Guid.NewGuid(),
                LastName = "Владимиров",
                FirstName = "Владимир",
                Patronymic = "Владимирович",
                Salary = 155m
            };
            Users.Add(vladimir);
            var grigory = new User
            {
                Id = Guid.NewGuid(),
                LastName = "Григорьев",
                FirstName = "Григорий",
                Patronymic = "Григорьевич",
                Salary = 101m
            };
            Users.Add(grigory);
            var dmitry = new User
            {
                Id = Guid.NewGuid(),
                LastName = "Дмитриев",
                FirstName = "Дмитрий",
                Patronymic = "Дмитриевич",
                Salary = 200m
            };
            Users.Add(dmitry);
        }
    }
}
