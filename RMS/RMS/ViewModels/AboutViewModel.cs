using RMS.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RMS.Data;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        public AboutViewModel()
        {
            Title = "About";
            LoginCommand = new Command(async () => await gravar());

        }

        public async Task gravar()
        {
        }

    }
}