using RMS.Data;
using RMS.Data.Interfaces;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class CarrinhoViewModel :  ItemCarrinhoViewModel
    {

        public ObservableCollection<CARRINHO> ProdutosCarrinhos { get; }

        private IRepository<CARRINHO> _carrinhoRepository;

        public CarrinhoViewModel()
        {
            _carrinhoRepository = new Repository<CARRINHO>();

            var produtosCarrinho = _carrinhoRepository.Get().Result;

            ProdutosCarrinhos = new ObservableCollection<CARRINHO>(produtosCarrinho);

        }
    }
}