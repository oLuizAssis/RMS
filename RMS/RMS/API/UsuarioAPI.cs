using RMS.API.Base;
using RMS.Models;
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

        public async Task<USUARIO> ObterProdutos(string email)
        => await Get($"/ObterUsuario?email={email}");

    }
}