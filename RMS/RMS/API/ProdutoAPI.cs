using RMS.API.Base;
using RMS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API
{
    public class ProdutoAPI : BaseAPI<PRODUTO>
    {
        public ProdutoAPI() :base("Produto")
        {
        }

        public async Task<List<PRODUTO>> ObterProdutos()
        {
            var X = await GetList($"");

            return X.ToList();
        }

    }
}