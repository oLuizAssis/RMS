using RMS.API;
using RMS.Models;
using RMS.Services;
using RMS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RMS.ViewModels
{
    public class CadastrarFuncionarioViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }


        private string _nome;
        public string Nome { get { return _nome; } set { SetProperty(ref _nome, value); } }

        private string _Cpf;
        public string Cpf { get { return _Cpf; } set { SetProperty(ref _Cpf, value); } }
        
        private string _dtnascimento;
        public string DtNasc { get { return _dtnascimento; } set { SetProperty(ref _dtnascimento, value); } }

        private string _cargo;
        public string Cargo { get { return _cargo; } set { SetProperty(ref _cargo, value); } }
        
        private string _email;
        public string Email { get { return _email; } set { SetProperty(ref _email, value); } }

        private string _endereco;
        public string Endereco { get { return _endereco; } set { SetProperty(ref _endereco, value); } }

        private string _contato;
        public string Contato { get { return _contato; } set { SetProperty(ref _contato, value); } }

        private string _senha;
        public string Senha { get { return _senha; } set { SetProperty(ref _senha, value); } }

        public CadastrarFuncionarioViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

        }

        public async void OnLoginClicked()
        {
            var funcionario = new USUARIO
            {
                NOME= Nome,
                CPF = Cpf,
                DTNASCIMENTO = DtNasc,
                EMAIL = Email,
                ENDERECO = Endereco,
                CONTATO = Contato,
                PERFIL = "Vendedor",
                SENHA = Senha
            };

            await new UsuarioAPI().SALVAR(funcionario);

            Application.Current.MainPage = new AppShell();

        }
    }
}
