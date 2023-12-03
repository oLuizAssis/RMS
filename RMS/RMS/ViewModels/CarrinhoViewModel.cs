using RMS.Data;
using RMS.Data.Interfaces;
using RMS.Models;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class CarrinhoViewModel : BaseViewModel
    {

        private ObservableCollection<CARRINHO> _produtosCarrinhos;
        public ObservableCollection<CARRINHO> ProdutosCarrinhos
        {
            get { return _produtosCarrinhos; }

            set { SetProperty(ref _produtosCarrinhos, value); }
        }


        private IRepository<CARRINHO> _carrinhoRepository;

        public Command LimparCarinhoCommad { get; }
        public Command FinalizarCompraCommad { get; }

        public CarrinhoViewModel()
        {
            LimparCarinhoCommad = new Command(LimparCarinho);

            FinalizarCompraCommad = new Command(FinalizarCompra);

            _produtosCarrinhos = new ObservableCollection<CARRINHO>();
        }

        public void OnAppearing()
        {
            _produtosCarrinhos.Clear();

            _carrinhoRepository = new Repository<CARRINHO>();

            var produtosCarrinho = _carrinhoRepository.Get().Result;

            foreach (var item in produtosCarrinho)
            {
                _produtosCarrinhos.Add(item);
            }

        }

        public void LimparCarinho()

        {
            _produtosCarrinhos.Clear();
            _carrinhoRepository.DeleteAll();
        }

        public void FinalizarCompra()
        {
            Shell.Current.GoToAsync($"//{nameof(PagamentosPage)}").ConfigureAwait(true);
        }
    }
}