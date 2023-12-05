using RMS.Data.Interfaces;
using RMS.Data;
using RMS.Models;
using RMS.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagamentosPage : ContentPage
    {
        PagamentosViewModel _viewModel;

        private IRepository<CARRINHO> _carrinhoRepository;

        public ObservableCollection<CARRINHO> ProdutosSelecionados { get; set; }


        public PagamentosPage()
        {
            InitializeComponent();

            var ProdutosSelecionados = new ObservableCollection<CARRINHO>();
            _carrinhoRepository = new Repository<CARRINHO>();

            var produtosCarrinho = _carrinhoRepository.Get().Result;

            foreach (var item in produtosCarrinho)
            {
                ProdutosSelecionados.Add(item);
            }

            carouselProdutos.ItemsSource = ProdutosSelecionados;

            valorTotalLabel.Text = $"Valor Total: R${produtosCarrinho.Sum(x => x.VALOR_TOTAL)}";

            this.BindingContext = new CadastrarFuncionarioViewModel();
        }



        // Métodos de Evento para Botões (exemplo)
        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            // Lógica para o botão Cancelar
        }

        private void RetornarAoCarrinho_Clicked(object sender, EventArgs e)
        {
            // Lógica para o botão Retornar ao Carrinho
        }

        private void FinalizarCompra_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("Parabens", $"Sua compra foi realizada com sucesso!", "Ok").ConfigureAwait(true);

            _carrinhoRepository.DeleteAll();

            Shell.Current.GoToAsync($"//{nameof(AboutPage)}").ConfigureAwait(true);

        }
    }
}