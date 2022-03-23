using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Exceptions;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Application.Wrappers;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Commands.DeleteFuncionarioById
{
    public class DeleteFuncionarioByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFuncionarioByIdCommandHandler : IRequestHandler<DeleteFuncionarioByIdCommand, Response<int>>
        {
            private readonly IFuncionarioRepositoryAsync _funcionarioRepository;
            public DeleteFuncionarioByIdCommandHandler(IFuncionarioRepositoryAsync funcionarioRepository)
            {
                _funcionarioRepository = funcionarioRepository;
            }
            public async Task<Response<int>> Handle(DeleteFuncionarioByIdCommand command, CancellationToken cancellationToken)
            {
                var funcionario = await _funcionarioRepository.GetByIdAsync(command.Id);
                if (funcionario == null) throw new ApiException($"Funcionario Não encontrado.");
                await _funcionarioRepository.DeleteAsync(funcionario);
                return new Response<int>(funcionario.Id);
            }
        }
    }
}
