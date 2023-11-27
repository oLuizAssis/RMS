using RMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarLoginPage : ContentPage
    {
        public CriarLoginPage()
        {
            InitializeComponent();
            this.BindingContext = new CriarLoginViewModel();
        }

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    // Realize qualquer lógica necessária quando a página deixa de ser visível

        //    // Navegue para a página de login
        //    Shell.Current.GoToAsync(nameof(LoginPage));
        //}

        protected override bool OnBackButtonPressed()
        {
            // Realize qualquer lógica necessária ao pressionar o botão "voltar"

            // Navegue para a página de login
            Application.Current.MainPage = new LoginPage();

            return true; // Indica que o evento foi manipulado
        }
    }
}