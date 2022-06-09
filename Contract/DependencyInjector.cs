using Contract.Basic;
using Microsoft.Extensions.DependencyInjection;

namespace Contract
{
    public static class DependencyInjector
    {
        public static void Start(IServiceCollection services)
        {
            Service.DependencyInjector.Start(services);

            services.AddScoped<IApplicationUserContract, ApplicationUserContract>();
        }
    }
}