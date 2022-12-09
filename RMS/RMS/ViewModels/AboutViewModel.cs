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

namespace RMS.ViewModels
{   
    public class AboutViewModel : BaseViewModel
    {

        private IRepository<PRODUTO> _ProdutoRepository;
        private IRepository<CARRINHO> _carrinhoRepository;
        public PRODUTO SelectedItem 
        {
            get;
            set;
        }

        public ObservableCollection<PRODUTO> Produtos { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<PRODUTO> ItemTappedCommand { get; }

    public AboutViewModel()
        {
            ItemTappedCommand = new Command<PRODUTO>(async (item) => await OnTapped(item));
            _ProdutoRepository = new Repository<PRODUTO>();
            _carrinhoRepository = new Repository<CARRINHO>();
            Title = "Produtos";
            var teste = InserirProdutos();
            var produtos = _ProdutoRepository.Get().Result;
            Produtos = new ObservableCollection<PRODUTO>(produtos);
        }

        public int InserirProdutos()
        {

            var produtos = new List<PRODUTO>();
            var item = new PRODUTO()
            {
                DESCRIÇÃO = "teste",
                TITULO = "luiz viado",
            };

            var item2 = new PRODUTO()
            {
                DESCRIÇÃO = "teste2",
                TITULO = "test5",
            };

            produtos.Add(item);
            produtos.Add(item2);
            _ProdutoRepository.InsertList(produtos);

            return 1;
        }

        public async Task OnTapped(PRODUTO produto)
        {
            var validaItem = _carrinhoRepository.GetFirst(c => c.ID_PRODUTO == produto.ID).Result;
            if(validaItem != null)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Item já foi adicionado", "OK");
            }
            else
            {
                await _carrinhoRepository.Insert(new CARRINHO()
                {
                    ID_PRODUTO = produto.ID
                });
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