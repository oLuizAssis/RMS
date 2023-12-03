using RMS.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RMS.Data;
using Xamarin.Forms;
using RMS.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using RMS.Data.Interfaces;
using System.Collections.Generic;
using Acr.UserDialogs;
using RMS.Services;
using RMS.API;
using System.Linq;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;

namespace RMS.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        private IRepository<PRODUTO> _ProdutoRepository;
        private IRepository<CARRINHO> _carrinhoRepository;
        ProdutoService _produtoService = new ProdutoService();

        public PRODUTO SelectedItem { get; set; }

        public int UltimaQuantidadeDeCaracteres { get; set; }
        public bool JaCarregouTodos { get; set; }

        private string itemId;

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

       

        private bool _isSearchVisible;
        public bool IsSearchVisible
        {
            get { return _isSearchVisible; }
            set
            {
                if (_isSearchVisible != value)
                {
                    _isSearchVisible = value;
                    OnPropertyChanged(nameof(IsSearchVisible));
                }
            }
        }


        public List<PRODUTO> _listaProdutos { get; set; }

        private ObservableCollection<PRODUTO> _produtos;
        public ObservableCollection<PRODUTO> Produtos
        {
            get { return _produtos; }

            set { SetProperty(ref _produtos, value); }
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<PRODUTO> ItemTappedCommand { get; }
        public ICommand ToggleSearchCommand => new Command(ToggleSearch);

        public AboutViewModel()
        {
            ItemTappedCommand = new Command<PRODUTO>(async (item) => await OnTapped(item));
            _produtos = new ObservableCollection<PRODUTO>();
            _ProdutoRepository = new Repository<PRODUTO>();
            _carrinhoRepository = new Repository<CARRINHO>();
            Title = "Produtos";

            MontarMenuLateral();
        }

        public void OnAppearing()
        {
            Task.Run(async () => await CarregarProdutos()).Wait();
        }

        public async Task CarregarProdutos()
        {
            _produtos.Clear();

            _listaProdutos = await new ProdutoAPI().ObterProdutos();

            foreach (var item in _listaProdutos)
            {
                _produtos.Add(item);
            }
        }



        public async Task OnTapped(PRODUTO produto)
        {

            var itemCarrinho = await _carrinhoRepository.GetFirst(c => c.ID_PRODUTO == produto.ID);

            if (itemCarrinho != null)
            {
                try
                {
                    var promptPage = new ModalSeletorProduto(itemCarrinho, produto.ESTOQUE, false);
                    //await Shell.Current.Navigation.PushModalAsync(new NavigationPage(promptPage));
                    await PopupNavigation.Instance.PushAsync(promptPage);
                }
                catch (Exception ex)
                {
                    return;
                }



            }
            else
            {
                var carinho = new CARRINHO()
                {
                    ID_PRODUTO = produto.ID,
                    FOTO = produto.FOTO,
                    NOME_PRODUTO = produto.DESCRICAO,
                    VALOR_PRODUTO = produto.VALORPRODUTO,
                    VALOR_TOTAL = produto.VALORPRODUTO,
                    QUANTIDADE = 0

                };

                var promptPage = new ModalSeletorProduto(carinho, produto.ESTOQUE, true);
                await PopupNavigation.Instance.PushAsync(promptPage);

            }

        }

        // Luiz - Carrinho icone

        public async Task OnTapped(CARRINHO produto)
        {

            // MESMO MÉTODO PARA CONTABILIZARR O CARRINHO?

            var validaItem = _carrinhoRepository.GetFirst(c => c.ID_PRODUTO == produto.ID).Result;

            var descricao = _listaProdutos.Where(c => c.ID == produto.ID).Select(c => c.DESCRICAO).FirstOrDefault();

            if (validaItem != null)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", $"Item {descricao} já foi adicionado", "OK");
            }
            else
            {
                var valida = await App.Current.MainPage.DisplayAlert("Atenção", $"Deseja excluir o item {descricao} do carrinho", "Sim", "Não");

                if (valida)
                {
                    await _carrinhoRepository.Insert(new CARRINHO()
                    {
                        ID_PRODUTO = produto.ID
                    });
                }

            }

        }

        private void MontarMenuLateral()
        {
            var listRotas = new List<string> { "Adicionar Produtos", "Cadastrar Funcionário" };
            var shellItem = Shell.Current.Items.Where(item => listRotas.Contains(item.Title)).ToList();

            if (shellItem != null)
            {
                if (SecureStorage.GetAsync("PerfilUsuario").Result == "Vendedor")
                    shellItem.ForEach(x => x.IsVisible = true);
                else
                    shellItem.ForEach(x => x.IsVisible = false);
            }
        }

        private void ToggleSearch()
        {
            IsSearchVisible = !IsSearchVisible;
        }
    }
}