using RMS.Services;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class CriarLoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }


        private string _senha;
        public string Senha { get { return _senha; } set { SetProperty(ref _senha, value); } }

        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        public CriarLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

        }

        public async void OnLoginClicked()
        {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

        }
    }
}
