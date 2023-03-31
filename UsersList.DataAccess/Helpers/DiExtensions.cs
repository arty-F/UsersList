using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UsersList.DataAccess
{
    public static class DiExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connection)
        {
            services.AddDbContext<UsersListDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(connection);
            });
            return services;
        }
    }
}
