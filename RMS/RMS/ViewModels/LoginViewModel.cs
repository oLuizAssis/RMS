using System;
using RMS.Views;
using RMS.Services;
using Xamarin.Forms;
using Acr.UserDialogs;
using Xamarin.Essentials;
using System.Threading.Tasks;
using RMS.Views.Login;

namespace RMS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region COMMANDS
        public Command LoginCommand { get; }
        public Command CriarUsuarioCommand { get; }

        #endregion

        LoginService _LoginService = new LoginService();
        protected IUserDialogs userDialogs { get; private set; }


        private string _senha;
        public string Senha { get { return _senha; } set { SetProperty(ref _senha, value); } }

        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        private Color _cor_Borda;
        public Color Cor_Borda { get { return _cor_Borda; } set { SetProperty(ref _cor_Borda, value); } }

        private bool _lembrar_Login;
        public bool Lembrar_Login { get { return _lembrar_Login; } set { SetProperty(ref _lembrar_Login, value); } }



        public LoginViewModel()
        {
            Cor_Borda = Color.Gray;

            if (!Lembrar_Login)
            {
                Email = null;
                Senha = null;
            }

            LoginCommand = new Command(OnLoginClicked);
            CriarUsuarioCommand = new Command(CriarUsuarioClick);
        }

        private async void OnLoginClicked(object obj)
        {
            var retorno = await _LoginService.Logar(Email, Senha);

            if (retorno)
                Application.Current.MainPage = new AppShell();
            else
            {
                Cor_Borda = Color.Red;
                await App.Current.MainPage.DisplayAlert("Atenção", "Email ou Senha Incorretos", "OK");
            }

        }

        private async void CriarUsuarioClick()
        {
            await Shell.Current.GoToAsync(nameof(CriarLoginPage));
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
