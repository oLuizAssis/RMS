using RMS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriarLoginPage : ContentPage
    {
        public CriarLoginPage()
        {
            InitializeComponent();
            this.BindingContext = new CriarLoginViewModel();
        }
    }
}