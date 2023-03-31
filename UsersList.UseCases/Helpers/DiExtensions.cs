using Microsoft.Extensions.DependencyInjection;

namespace UsersList.UseCases
{
    public static class DiExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DiExtensions).Assembly));
            return services;
        }
    }
}
