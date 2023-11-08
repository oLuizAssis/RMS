using RMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarrinhoPage : ContentPage
    {
        CarrinhoViewModel _viewModel;

        public CarrinhoPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CarrinhoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}