using RMS.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RMS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}