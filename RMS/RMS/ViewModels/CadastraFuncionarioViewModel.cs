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
    public class CriarLoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }


        private string _nome;
        public string NomeFuncionario { get { return _nome; } set { SetProperty(ref _nome, value); } }

        private string _Cpf;
        public string CpfFuncionario { get { return _Cpf; } set { SetProperty(ref _Cpf, value); } }
        
        private string _dtnascimento;
        public string DtNascFuncionario { get { return _dtnascimento; } set { SetProperty(ref _dtnascimento, value); } }

        private string _cargo;
        public string Cargo { get { return _cargo; } set { SetProperty(ref _cargo, value); } }
        
        private string _email;
        public string EmailFuncionario { get { return _email; } set { SetProperty(ref _email, value); } }

        private string _endereco;
        public string EnderecoFuncionario { get { return _endereco; } set { SetProperty(ref _endereco, value); } }

        private string _contato;
        public string ContatoFuncionario { get { return _contato; } set { SetProperty(ref _contato, value); } }

        private string _senha;
        public string Senha { get { return _senha; } set { SetProperty(ref _senha, value); } }

        public CriarLoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);

        }

        public async void OnLoginClicked()
        {
            var teste = new USUARIO
            {
                NOMEUSUARIO= nome
                SENHA= Senha,
                EMAIL= Email,

            };

            await new UsuarioAPI().SALVAR(teste);

                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

        }
    }
}
