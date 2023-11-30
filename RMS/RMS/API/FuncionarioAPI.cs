using RMS.API.Base;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API
{
    public class UsuarioAPI : BaseAPI<USUARIO>
    {
        public UsuarioAPI() : base("Usuario")
        {

        }

        public async Task<USUARIO> ObterUsuario(string email)
        => await Get($"/ObterUsuario?email={email}");

        public async Task<object> SALVAR(USUARIO email)
        => await PostObject($"/ObterUsuario", GetHttpContent(email));

        internal Task SALVAR(FUNCIONARIO funcionario)
        {
            throw new NotImplementedException();
        }
    }
}