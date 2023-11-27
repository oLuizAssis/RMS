using RMS.ViewModels;
using RMS.Views;
using RMS.Views.Login;
using System.Linq;
using Xamarin.Forms;

namespace RMS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegistrarRotas();

        }

        private void RegistrarRotas()
        {
            Routing.RegisterRoute(nameof(CriarLoginPage), typeof(CriarLoginPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ModalSeletorProduto), typeof(ModalSeletorProduto));
            Routing.RegisterRoute(nameof(CadastraFuncionarioPage), typeof(CadastraFuncionarioPage));
        }
    }
}
