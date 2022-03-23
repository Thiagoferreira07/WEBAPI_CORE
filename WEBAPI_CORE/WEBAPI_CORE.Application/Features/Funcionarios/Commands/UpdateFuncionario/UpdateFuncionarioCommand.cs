using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Exceptions;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Application.Wrappers;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Commands.UpdateFuncionario
{
    public class UpdateFuncionarioCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Numero_de_chapa { get; set; }
        public string Telefone { get; set; }
        public string Nome_Lider { get; set; }
        public class UpdateFuncionarioCommandHandler : IRequestHandler<UpdateFuncionarioCommand, Response<int>>
        {
            private readonly IFuncionarioRepositoryAsync _funcionarioRepository;
            public UpdateFuncionarioCommandHandler(IFuncionarioRepositoryAsync funcionarioRepository)
            {
                _funcionarioRepository = funcionarioRepository;
            }
            public async Task<Response<int>> Handle(UpdateFuncionarioCommand command, CancellationToken cancellationToken)
            {
                var funcionario = await _funcionarioRepository.GetByIdAsync(command.Id);

                if (funcionario == null)
                {
                    throw new ApiException($"Funcionario Não encontrado.");
                }
                else
                {
                    funcionario.Nome = command.Nome;
                    funcionario.Sobrenome = command.Sobrenome;
                    funcionario.Email = command.Email;
                    funcionario.Numero_de_chapa = command.Numero_de_chapa;
                    funcionario.Telefone = command.Telefone;
                    funcionario.Nome_Lider = command.Nome_Lider;

                    await _funcionarioRepository.UpdateAsync(funcionario);
                    return new Response<int>(funcionario.Id);
                }
            }
        }
    }
}
