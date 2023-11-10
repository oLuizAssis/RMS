using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using RMS.Data;
using RMS.Data.Interfaces;
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
    public partial class ModalSeletorProduto : PopupPage
    {
        private IRepository<CARRINHO> _carrinhoRepository;
        private CARRINHO _carrinho;

        public ModalSeletorProduto(CARRINHO carrinho, int quantidadeEstoque)
        {
            InitializeComponent();
            _carrinhoRepository = new Repository<CARRINHO>();

            quantityStepper = new Stepper
            {
                Minimum = 0,
                Maximum = quantidadeEstoque,
                Value = carrinho.QUANTIDADE,
                Increment = 1,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 120, // Defina o tamanho desejado
            };

            _carrinho = carrinho;

        }

        private async void AdicionarAoCarrinho(object sender, EventArgs e)
        {
            var quantidadeSelecionada = (int)quantityStepper.Value;

            if(quantidadeSelecionada == 0)
            {
                await _carrinhoRepository.Delete(_carrinho);
            }
            else
            {
                _carrinho.QUANTIDADE = quantidadeSelecionada;
                _carrinho.VALOR_TOTAL = _carrinho.QUANTIDADE * quantidadeSelecionada;

                await _carrinhoRepository.Update(_carrinho);
            }

            await PopupNavigation.Instance.PopAsync();
        }

    }
}