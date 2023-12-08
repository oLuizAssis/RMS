using RMS.ViewModels;
using System;
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

        private async void OnSalvarButtonClicked(object sender, EventArgs e)
        {
            // Lógica para salvar os dados no banco de dados
            // ...

            // Exibir mensagem de sucesso
            await DisplayAlert("Sucesso", "Novo usuário cadastrado com sucesso!", "OK");
        }
        protected override bool OnBackButtonPressed()
        {
            // Realize qualquer lógica necessária ao pressionar o botão "voltar"

            // Navegue para a página de login
            Application.Current.MainPage = new LoginPage();

            return true; // Indica que o evento foi manipulado
        }

        private void OnDateEntryTapped(object sender, EventArgs e)
        {
            datePicker.IsVisible = !datePicker.IsVisible;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            dateEntry.Text = e.NewDate.ToString("D");
            datePicker.IsVisible = false;
        }
    }
}