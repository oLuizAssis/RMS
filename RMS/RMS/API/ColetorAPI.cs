using RMS.API.Base;
using RMS.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API
{
    public class ProdutoAPI : BaseAPI<PRODUTO>
    {
        public ProdutoAPI() : base("Produto")
        {
        }

        public async Task<PRODUTO> ObterProdutos()
        {
            var X = await Get($"");

            return X;
        }

    }
}