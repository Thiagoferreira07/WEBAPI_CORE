using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_CORE.Application.Features.Funcionarios.Commands;
using WEBAPI_CORE.Application.Features.Funcionarios.Commands.CreateFuncionario;
using WEBAPI_CORE.Application.Features.Funcionarios.Commands.DeleteFuncionarioById;
using WEBAPI_CORE.Application.Features.Funcionarios.Commands.UpdateFuncionario;
using WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetAllFuncionario;
using WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetFuncionarioById;
using WEBAPI_CORE.Application.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEBAPI_CORE.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FuncionarioController : BaseApiController
    {
        // GET: api/<controller>
        /// <summary>
        /// Retornar todos os Funcionarios registrados passando os parametros de PageSize, PageNumber
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFuncionarioParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllFuncionarioQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        /// <summary>
        /// Retorna funcionario pelo ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFuncionarioByIdQuery { Id = id }));
        }

        // POST api/<controller>
        /// <summary>
        /// Insere o Funcionario na base conforme as informações dadas
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateFuncionarioCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Atualiza Funcionario com novas informações dadas, utilizando o ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateFuncionarioCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Deleta Funcionario da base pelo ID fornecido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFuncionarioByIdCommand { Id = id }));
        }
    }
}
