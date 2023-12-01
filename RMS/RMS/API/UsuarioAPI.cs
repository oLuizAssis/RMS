using RMS.API.Base;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API
{
    public class FuncionarioAPI : BaseAPI<FUNCIONARIO>
    {
        public FuncionarioAPI() : base("Funcionario")
        {

        }

        public async Task<FUNCIONARIO> ObterUsuario(string email)
        => await Get($"/ObterUsuario?email={email}");

        public async Task<object> SALVAR(FUNCIONARIO email)
        => await PostObject($"/ObterUsuario", GetHttpContent(email));

        internal Task SALVE(FUNCIONARIO funcionario)
        {
            throw new NotImplementedException();
        }
    }
}