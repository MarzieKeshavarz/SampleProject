using Microsoft.Extensions.DependencyInjection;
using Service.Base;
using Service.Basic;

namespace Service
{
    public static class DependencyInjector
    {
        public static void Start(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseAuditService<,>), typeof(BaseAuditService<,>));

            services.AddScoped(typeof(IBaseIdentityService<,>), typeof(BaseIdentityService<,>));

            services.AddScoped<IApplicationUserService, ApplicationUserService>();
        }
    }
}