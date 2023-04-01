using Microsoft.EntityFrameworkCore;
using UsersList.Contracts.Entities;
using UsersList.DataAccess.Initializers;

namespace UsersList.DataAccess
{
    public class UsersListDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        public UsersListDbContext(DbContextOptions<UsersListDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var initializer = new UsersListDbInitializer();
            modelBuilder.Entity<Department>().HasData(initializer.Departments);
            modelBuilder.Entity<User>().HasData(initializer.Users);

            base.OnModelCreating(modelBuilder);
        }
    }
}
