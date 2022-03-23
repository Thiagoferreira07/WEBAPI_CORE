using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEBAPI_CORE.Application.Interfaces;
using WEBAPI_CORE.Domain.Settings;
using WEBAPI_CORE.Infrastructure.Shared.Services;

namespace WEBAPI_CORE.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
