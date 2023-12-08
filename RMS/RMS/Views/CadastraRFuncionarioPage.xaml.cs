using RMS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarFuncionarioPage : ContentPage
    {
        public CadastrarFuncionarioPage()
        {
            InitializeComponent();
            this.BindingContext = new CadastrarFuncionarioViewModel();
        }


        private async void OnSalvarButtonClicked(object sender, EventArgs e)
        {
            // Lógica para salvar os dados no banco de dados
            // ...

            // Exibir mensagem de sucesso
            await DisplayAlert("Sucesso", "Novo funcionário cadastrado com sucesso!", "OK");
        }
        //protected override bool OnBackButtonPressed()
        //{
        //    return base.OnBackButtonPressed();
        //}

        protected void OnDateEntryTapped(object sender, EventArgs e)
        {
         //   datePicker.IsVisible = !datePicker.IsVisible;
        }

        private void OnDateEntryTapped(object sender, DateChangedEventArgs e)
        {
        //    dateEntry.Text = e.NewDate.ToString("D");
        //    datePicker.IsVisible = false;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            dateEntry.Text = e.NewDate.ToString("D");
            datePicker.IsVisible = false;
        }

        //private void InitializeComponent()
        //{
        //    throw new NotImplementedException();
        //}
    }
}