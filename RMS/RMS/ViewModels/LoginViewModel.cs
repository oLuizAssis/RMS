using RMS.Services;
using RMS.Views;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        LoginService _LoginService = new LoginService();


        private string _senha;
        public string Senha
        {
            get { return _senha; }
            set { SetProperty(ref _senha, value); }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }




        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var retorno = await _LoginService.Logar(Email);
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public async Task EnviaSms()
        {

            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var level = Battery.ChargeLevel;
            var location = await Geolocation.GetLastKnownLocationAsync();
            var state = Battery.State;

            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            var teste = ImageSource.FromStream(() => stream);

            var mensagem = new SmsMessage("gui gay", "67984486415");
                await Sms.ComposeAsync(mensagem);
        }
    }
}
