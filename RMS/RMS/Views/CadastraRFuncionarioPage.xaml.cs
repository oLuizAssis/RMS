using RMS.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RMS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarFuncionarioPage : ContentPage
    {
        public CadastrarFuncionarioPage()
        {
            InitializeComponent();
            this.BindingContext = new CadastrarFuncionarioViewModel();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}