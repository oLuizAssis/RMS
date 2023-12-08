using RMS.API.Base;
using RMS.Models;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace RMS.API
{
    public class ItemsPageAPI : BaseAPI<ITEMSPAGE>
    {
        public ItemsPageAPI() : base("ItemsPage")
        {

        }

        internal Task SALVAR(object itemspage)
        {
            throw new NotImplementedException();
        }

        //public async Task<ITEMSPAGE> ObterUsuario(string email)
        //=> await Get($"/ObterUsuario?email={email}");


        // alterar na API
        //public async Task<object> SALVAR(ITEMSPAGE novoItem)
        //=> await PostObject($"/CadastrarUsuario", GetHttpContent(novoItem));

        //internal Task SALVAR(USUARIO usuario)
        //{
        //    throw new NotImplementedException();
        //}
    }
}