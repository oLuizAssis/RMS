using System;
using RMS.Views;
using RMS.Services;
using Xamarin.Forms;
using Acr.UserDialogs;
using Xamarin.Essentials;
using System.Threading.Tasks;
using RMS.Views.Login;
using RMS.API;
using System.ComponentModel;
using System.Diagnostics;
using RMS.Models;

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
            var retorno = await new UsuarioAPI().ObterProdutos(Email);

            ValidaDadosUsuario(retorno);
        }

        private async void ValidaDadosUsuario(USUARIO usuario)
        {
            if (usuario == null)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Email não cadastrado", "OK");
            }
            else
            {
                if (usuario.SENHA == Senha) 
                    Application.Current.MainPage = new AppShell(true);
                else
                    await App.Current.MainPage.DisplayAlert("Atenção", "Senha incorreta", "OK");
            }
        }

        private async void CriarUsuarioClick()
        {
            try
            {
                Application.Current.MainPage = new AppShell(false);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

    }
}
