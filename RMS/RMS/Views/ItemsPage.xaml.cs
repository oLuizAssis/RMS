using RMS.Models;
using RMS.ViewModels;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        private async void OnSalvarButtonClicked(object sender, EventArgs e)
        {
            // Lógica para salvar os dados no banco de dados
            // ...

            // Exibir mensagem de sucesso
            await DisplayAlert("Concluído", "Item salvo com sucesso!", "OK");


            //// Limpar os campos do formulário
            //((ItemsPageViewModel)BindingContext).Titulo = "";
            //((ItemsPageViewModel)BindingContext).Descricao = "";
            //((ItemsPageViewModel)BindingContext).NumeroSerie = "";
            //((ItemsPageViewModel)BindingContext).Categoria = "";
            //((ItemsPageViewModel)BindingContext).Status = "";
            //((ItemsPageViewModel)BindingContext).Marca = "";
            //((ItemsPageViewModel)BindingContext).Valor = "";

            //// Certifique-se de que as propriedades estejam notificando as alterações
            //OnPropertyChanged(nameof(ItemsPageViewModel.Titulo));
            //OnPropertyChanged(nameof(ItemsPageViewModel.Descricao));
            //OnPropertyChanged(nameof(ItemsPageViewModel.NumeroSerie));
            //OnPropertyChanged(nameof(ItemsPageViewModel.Categoria));
            //OnPropertyChanged(nameof(ItemsPageViewModel.Status));
            //OnPropertyChanged(nameof(ItemsPageViewModel.Marca));
            //OnPropertyChanged(nameof(ItemsPageViewModel.Valor));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            BindingContext = _viewModel = new ItemsViewModel();
        }
    }
}