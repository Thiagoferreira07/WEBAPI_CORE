using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Application.Wrappers;
using WEBAPI_CORE.Domain.Entities;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Commands.CreateFuncionario
{
    public partial class CreateFuncionarioCommand : IRequest<Response<int>>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Numero_de_chapa { get; set; }
        public string Telefone { get; set; }
        public string Nome_Lider { get; set; }
        
    }
    public class CreateFuncionarioCommandHandler : IRequestHandler<CreateFuncionarioCommand, Response<int>>
    {
        private readonly IFuncionarioRepositoryAsync _funcionarioRepository;
        private readonly IMapper _mapper;
        public CreateFuncionarioCommandHandler(IFuncionarioRepositoryAsync funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = _mapper.Map<Funcionario>(request);
            await _funcionarioRepository.AddAsync(funcionario);
            return new Response<int>(funcionario.Id);
        }
    }
}
