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
    public class ItemsPageViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }


        private string _titulo;
        public string Titulo { get { return _titulo; } set { SetProperty(ref _titulo, value); } }

        private string _descricao;
        public string Descricao { get { return _descricao; } set { SetProperty(ref _descricao, value); } }

        private string _numeroSerie;
        public string NumeroSerie { get { return _numeroSerie; } set { SetProperty(ref _numeroSerie, value); } }

        private string _categoria;
        public string Categoria { get { return _categoria; } set { SetProperty(ref _categoria, value); } }

        private string _status;
        public string Status { get { return _status; } set { SetProperty(ref _status, value); } }

        private string _marca;
        public string Marca { get { return _marca; } set { SetProperty(ref _marca, value); } }

        private string _valor;
        public string Valor { get { return _valor; } set { SetProperty(ref _valor, value); } }
        public ItemsPageViewModel()
        {
           // LoginCommand = new Command(OnLoginClicked);

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
            var itemspage = new ITEMSPAGE
            {
                TITULO = Titulo,
                DESCRICAO = Descricao,
                NUMEROSERIE = NumeroSerie,
                CATEGORIA = Categoria,
                STATUS = Status,
                MARCA = Marca,
                VALOR = Valor
            };

            await new ItemsPageAPI().SALVAR(itemspage);

            Application.Current.MainPage = new AppShell();

        }
    }
}
