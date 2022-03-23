using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WEBAPI_CORE.Application.Features.Funcionarios.Commands.CreateFuncionario;
using WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetAllFuncionario;
using WEBAPI_CORE.Domain.Entities;

namespace WEBAPI_CORE.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Funcionario, GetAllFuncionarioViewModel>().ReverseMap();
            CreateMap<CreateFuncionarioCommand, Funcionario>();
            CreateMap<GetAllFuncionarioQuery, GetAllFuncionarioParameter>();
        }
    }
}
