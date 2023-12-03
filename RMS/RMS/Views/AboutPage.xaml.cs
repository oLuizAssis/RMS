using RMS.Models;
using RMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        AboutViewModel _viewModel;

        public AboutPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarItensFiltrados(e.NewTextValue);
        }

        private void AtualizarItensFiltrados(string termoDePesquisa)
        {
            if(termoDePesquisa.Length > 3)
            {
                var itensAtuais = ItemsListView.ItemsSource as IEnumerable<PRODUTO>;

                if(itensAtuais != null)
                {
                    var itensFiltrados = itensAtuais.Where(item => item.DESCRICAO.ToUpper().Contains(termoDePesquisa.ToUpper())).ToList();

                    if(itensFiltrados != null) 
                        ItemsListView.ItemsSource = itensFiltrados;

                    _viewModel.JaCarregouTodos = false;
                }
            }
            else
            {
                if(_viewModel.UltimaQuantidadeDeCaracteres > termoDePesquisa.Length && !_viewModel.JaCarregouTodos)
                {
                    ItemsListView.ItemsSource = _viewModel._listaProdutos;
                    _viewModel.JaCarregouTodos = true;
                }
            }

            _viewModel.UltimaQuantidadeDeCaracteres = termoDePesquisa.Length;
        }


    }
}