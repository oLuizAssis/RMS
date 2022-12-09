using RMS.API.Base;
using RMS.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RMS.API
{
    public class ColetorAPI : BaseAPI<PRODUTO>
    {
        public ColetorAPI() : base("Coletor", (string)Application.Current.Properties["CONCESSAO"])
        {
        }

        public ColetorAPI(ConfiguracaoModel Configuracao) : base("Coletor", (string)Application.Current.Properties["CONCESSAO"], Configuracao)
        {
        }

        public async Task<ColetorModel> BuscarPorIdUnique(string UniqueID)
        {
            var X = await Get($"ObterColetorPorMac/{UniqueID}");

            return X;
        }

        public async Task<bool> InsertColetor(ColetorModel obj)
        {
            string vLeiturista = Application.Current.Properties["ID_LEITURISTA"].ToString();

            return (bool)await PostObject($"SalvarColetorMobile?IdLeiturista={vLeiturista.ToString()}", GetHttpContent(obj));
        }
    }
}