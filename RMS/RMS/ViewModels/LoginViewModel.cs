using RMS.Views;
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

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);

            var level = Battery.ChargeLevel;
            var location = await Geolocation.GetLastKnownLocationAsync();
            var state = Battery.State;

            await EnviaSms();

            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public async Task EnviaSms()
        {
            var screenshot = await Screenshot.CaptureAsync();
            var stream = await screenshot.OpenReadAsync();

            var teste = ImageSource.FromStream(() => stream);

            var mensagem = new SmsMessage("gui gay", "67984486415");
                await Sms.ComposeAsync(mensagem);
        }
    }
}
