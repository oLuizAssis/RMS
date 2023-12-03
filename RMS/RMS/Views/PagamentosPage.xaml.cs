using RMS.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagamentosPage : ContentPage
    {
        PagamentosViewModel _viewModel;

        public PagamentosPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PagamentosViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}