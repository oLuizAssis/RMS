using RMS.API;
using RMS.Models;
using RMS.Services;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class CriarLoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }


        private string _nome;
        public string Nome { get { return _nome; } set { SetProperty(ref _nome, value); } }

        private string _Cpf;
        public string Cpf { get { return _Cpf; } set { SetProperty(ref _Cpf, value); } }

        private string _dtnascimento;
        public string DtNascimento { get { return _dtnascimento; } set { SetProperty(ref _dtnascimento, value); } }

        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        private string _endereco;
        public string Endereco { get { return _endereco; } set { SetProperty(ref _endereco, value); } }

        private string _contato;
        public string Contato { get { return _contato; } set { SetProperty(ref _contato, value); } }

        private string _senha;
        public string Senha { get { return _senha; } set { SetProperty(ref _senha, value); } }
        public CriarLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);


        }


        // public ICommand SalvarCommand { get; }

        //public CriarLoginViewModel()
        //        {
        //            SalvarCommand = new Command(OnSalvar);
        //        }

        //        private void OnSalvar()
        //        {
        //            // Lógica para salvar o cadastro do novo usuário
        //            // Isso pode incluir a validação dos dados do formulário e o salvamento no banco de dados, por exemplo.
        //        }


        public async void OnLoginClicked()
        {
            var usuario = new USUARIO
            {
                NOME = Nome,
                CPF = Cpf,
                DTNASCIMENTO = DtNascimento,
                EMAIL = Email,
                ENDERECO = Endereco,
                PERFIL = "Comprador",
                CONTATO = Contato,
                SENHA = Senha
            };

            await new UsuarioAPI().SALVAR(usuario);

            Application.Current.MainPage = new AppShell();

        }
    }
}
