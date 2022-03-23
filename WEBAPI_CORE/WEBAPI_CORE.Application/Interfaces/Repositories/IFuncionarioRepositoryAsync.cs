using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WEBAPI_CORE.Domain.Entities;

namespace WEBAPI_CORE.Application.Interfaces.Repositories
{
    public interface IFuncionarioRepositoryAsync : IGenericRepositoryAsync<Funcionario>
    {
        Task<bool> IsUniqueBarcodeAsync(string numeroChapa);
    }
}
