using RMS.Data;
using RMS.Services;
using RMS.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using RMS.Data.Interfaces;
using RMS.Models;
using Rg.Plugins.Popup;


//DbContext?

namespace RMS
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            CreateAllTables();

            DependencyService.Register<MockDataStore>();
            new AppShell();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void CreateAllTables()
        {

            // atualizar as models

            var db = DependencyService.Get<ISQLite>().GetConnection();

            db.CreateTable<Note>();
            db.CreateTable<USUARIO>();
            db.CreateTable<PRODUTO>();
            db.CreateTable<CARRINHO>();


        }

    }
}
