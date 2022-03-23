using System;
using System.Collections.Generic;
using System.Text;

namespace WEBAPI_CORE.Application.Features.Funcionarios.Queries.GetAllFuncionario
{
    public class GetAllFuncionarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Numero_de_chapa { get; set; }
        public string Telefone { get; set; }
        public string Nome_Lider { get; set; }
    }
}
