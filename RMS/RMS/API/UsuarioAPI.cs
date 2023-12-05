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

        public async Task<object> SALVAR(USUARIO novoUsuario)
        => await PostObject($"/CadastrarUsuario", GetHttpContent(novoUsuario));

        //internal Task SALVAR(USUARIO usuario)
        //{
        //    throw new NotImplementedException();
        //}
    }
}