using RMS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _viewModel =  new LoginViewModel();

            DesabilitarMenuLateral();
            //ValidarLoginAutomatico().ConfigureAwait(true);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void DesabilitarMenuLateral()
        {
            if(Shell.Current != null)
                Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }

        private async Task LogarAutomaticamente()
        {
            if (Shell.Current != null)
                await Shell.Current.GoToAsync(nameof(AboutPage));
        }

        private async Task ValidarLoginAutomatico()
        {

            if (string.IsNullOrEmpty(await SecureStorage.GetAsync("DataLogin")))
                return;

            var dataLoginString = await SecureStorage.GetAsync("DataLogin");

            var dataLogin = Convert.ToDateTime(dataLoginString);

            var tempoDeLogin = dataLogin - DateTime.Now;

            if (tempoDeLogin.TotalHours <= 10)
                await LogarAutomaticamente();
        }

    }
}