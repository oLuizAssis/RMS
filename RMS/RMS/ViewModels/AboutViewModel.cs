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

namespace RMS.ViewModels
{   
    public class AboutViewModel : BaseViewModel
    {

        private IRepository<PRODUTO> _ProdutoRepository;
        private Item _selectedItem;

        public ObservableCollection<PRODUTO> Produtos { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public AboutViewModel()
        {
            _ProdutoRepository = new Repository<PRODUTO>();
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