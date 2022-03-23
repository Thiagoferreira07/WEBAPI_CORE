using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WEBAPI_CORE.Application.Interfaces;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Infrastructure.Persistence.Contexts;
using WEBAPI_CORE.Infrastructure.Persistence.Repositories;
using WEBAPI_CORE.Infrastructure.Persistence.Repository;

namespace WEBAPI_CORE.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IFuncionarioRepositoryAsync, FuncionarioRepositoryAsync>();
            #endregion
        }
    }
}
