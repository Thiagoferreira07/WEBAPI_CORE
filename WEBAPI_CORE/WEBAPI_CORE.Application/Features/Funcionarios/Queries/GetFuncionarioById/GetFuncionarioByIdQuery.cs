using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Exceptions;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Application.Wrappers;
using WEBAPI_CORE.Domain.Entities;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetFuncionarioById
{
    public class GetFuncionarioByIdQuery : IRequest<Response<Funcionario>>
    {
        public int Id { get; set; }
        public class GetFuncionarioByIdQueryHandler : IRequestHandler<GetFuncionarioByIdQuery, Response<Funcionario>>
        {
            private readonly IFuncionarioRepositoryAsync _funcionarioRepository;
            public GetFuncionarioByIdQueryHandler(IFuncionarioRepositoryAsync funcionarioRepository)
            {
                _funcionarioRepository = funcionarioRepository;
            }
            public async Task<Response<Funcionario>> Handle(GetFuncionarioByIdQuery query, CancellationToken cancellationToken)
            {
                var funcionario = await _funcionarioRepository.GetByIdAsync(query.Id);
                if (funcionario == null) throw new ApiException($"Funcionario Não encontrado.");
                return new Response<Funcionario>(funcionario);
            }
        }
    }
}
