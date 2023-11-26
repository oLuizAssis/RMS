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
using System.Globalization;
using RMS.Data;

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

        USUARIO _usuarioModel;

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
        public void OnAppearing()
        {
            InserirCredenciaisNosCamposAutomaticamentes();
        }


        private async void OnLoginClicked(object obj)
        {
            _usuarioModel = await new UsuarioAPI().ObterUsuario(Email);

            ValidaLogin();
        }

        private async void ValidaLogin()
        {
            if (_usuarioModel == null)
            {
                await App.Current.MainPage.DisplayAlert("Atenção", "Email não cadastrado", "OK");
            }
            else
            {
                if (_usuarioModel.SENHA == Senha)
                {
                    ValidarLoginAutomatico();

                    Application.Current.MainPage = new AppShell();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Atenção", "Senha incorreta", "OK");
            }
        }

        private void CriarUsuarioClick()
        {
            Application.Current.MainPage = new CriarLoginPage();
        }

        public void ValidarLoginAutomatico()
        {
            SecureStorage.SetAsync("PerfilUsuario", _usuarioModel.PERFIL);

            if (Lembrar_Login)
                CadastrarCredenciaisLogin();
            else
                RemoverCredenciaisLogin();
        }

        public void CadastrarCredenciaisLogin()
        {
            if (ValidarCredenciais())
            {
                SecureStorage.SetAsync("Email", _usuarioModel.EMAIL);
            }

        }

        public void RemoverCredenciaisLogin()
        {
            if (!ValidarCredenciais())
            {
                SecureStorage.Remove("Email");
            }
        }

        private bool ValidarCredenciais()
        {
            return string.IsNullOrEmpty(SecureStorage.GetAsync("Email").Result);
        }

        private void InserirCredenciaisNosCamposAutomaticamentes()
        {
            if (!ValidarCredenciais())
            {
                Email = SecureStorage.GetAsync("Email").Result;
                Lembrar_Login = true;
            }

        }

    }
}
