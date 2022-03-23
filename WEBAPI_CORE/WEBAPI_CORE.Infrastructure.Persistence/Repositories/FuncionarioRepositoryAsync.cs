using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Domain.Entities;
using WEBAPI_CORE.Infrastructure.Persistence.Contexts;
using WEBAPI_CORE.Infrastructure.Persistence.Repository;

namespace WEBAPI_CORE.Infrastructure.Persistence.Repositories
{
    public class FuncionarioRepositoryAsync : GenericRepositoryAsync<Funcionario>, IFuncionarioRepositoryAsync
    {
        private readonly DbSet<Funcionario> _funcionarios;

        public FuncionarioRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _funcionarios = dbContext.Set<Funcionario>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string numeroChapa)
        {
            return _funcionarios
                .AllAsync(p => p.Numero_de_chapa != numeroChapa);
        }
    }
}
