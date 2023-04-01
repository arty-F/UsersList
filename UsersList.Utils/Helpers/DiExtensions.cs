using Microsoft.Extensions.DependencyInjection;
using UsersList.Utils.Mapping;

namespace UsersList.Utils
{
    public static class DiExtensions
    {
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
