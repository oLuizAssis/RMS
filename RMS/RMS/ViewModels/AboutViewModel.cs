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

namespace RMS.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        private IRepository<PRODUTO> _ProdutoRepository;
        private IRepository<CARRINHO> _carrinhoRepository;
        ProdutoService _produtoService = new ProdutoService();

        public PRODUTO SelectedItem
        {
            get;
            set;
        }
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
                CarregarProdutos();
            }
        }

        public List<PRODUTO> _listaProdutos { get; set; }

        private ObservableCollection<PRODUTO> _produtos { get; set; }
        public ObservableCollection<PRODUTO> Produtos
        {
            get {
                Task.Run(async () => await CarregarProdutos()).Wait();
                    return _produtos;
            }
        }

        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<PRODUTO> ItemTappedCommand { get; }

        public AboutViewModel()
        {
            ItemTappedCommand = new Command<PRODUTO>(async (item) => await OnTapped(item));
            _ProdutoRepository = new Repository<PRODUTO>();
            _carrinhoRepository = new Repository<CARRINHO>();
            Title = "Produtos";

             Task.Run(async () => await CarregarProdutos()).Wait();
        }

        public async Task CarregarProdutos()
        {
            _listaProdutos = await new ProdutoAPI().ObterProdutos();

            _produtos = new ObservableCollection<PRODUTO>(_listaProdutos);

        }



        public async Task OnTapped(PRODUTO produto)
        {
            var validaItem = _carrinhoRepository.GetFirst(c => c.ID_PRODUTO == produto.ID).Result;

            var descricao = _listaProdutos.Where(c => c.ID == produto.ID).Select(c => c.DESCRICAO).FirstOrDefault();

            if (validaItem != null)
            {
               await App.Current.MainPage.DisplayAlert("Atenção", $"Item {descricao} já foi adicionado", "OK");
            }
            else
            {
               var valida =  await App.Current.MainPage.DisplayAlert("Atenção", $"Deseja adicionar o item {descricao} ao carrinho", "Sim", "Não");

                if (valida)
                {
                    await _carrinhoRepository.Insert(new CARRINHO()
                    {
                        ID_PRODUTO = produto.ID,
                        NOME_PRODUTO = produto.DESCRICAO
                    });
                }
                
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
               var valida =  await App.Current.MainPage.DisplayAlert("Atenção", $"Deseja excluir o item {descricao} do carrinho", "Sim", "Não");

                if (valida)
                {
                    await _carrinhoRepository.Insert(new CARRINHO()
                    {
                        ID_PRODUTO = produto.ID
                    });
                }
                
            }

        }



        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        //public void OnAppearing()
        //{
        //    IsBusy = true;
        //    SelectedItem = null;
        //}

        //public Item SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        SetProperty(ref _selectedItem, value);
        //        OnItemSelected(value);
        //    }
        //}

        //private async void OnAddItem(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(NewItemPage));
        //}

        //async void OnItemSelected(Item item)
        //{
        //    if (item == null)
        //        return;

        //    // This will push the ItemDetailPage onto the navigation stack
        //    await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        //}       

    }
}