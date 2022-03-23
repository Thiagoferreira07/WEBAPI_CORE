using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Filters;
using WEBAPI_CORE.Application.Interfaces.Repositories;
using WEBAPI_CORE.Application.Wrappers;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetAllFuncionario
{
    public class GetAllFuncionarioQuery : IRequest<PagedResponse<IEnumerable<GetAllFuncionarioViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllFuncionarioQueryHandler : IRequestHandler<GetAllFuncionarioQuery, PagedResponse<IEnumerable<GetAllFuncionarioViewModel>>>
    {
        private readonly IFuncionarioRepositoryAsync _funcionarioRepository;
        private readonly IMapper _mapper;
        public GetAllFuncionarioQueryHandler(IFuncionarioRepositoryAsync funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllFuncionarioViewModel>>> Handle(GetAllFuncionarioQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllFuncionarioParameter>(request);
            var funcionario = await _funcionarioRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var funcionarioViewModel = _mapper.Map<IEnumerable<GetAllFuncionarioViewModel>>(funcionario);
            return new PagedResponse<IEnumerable<GetAllFuncionarioViewModel>>(funcionarioViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
