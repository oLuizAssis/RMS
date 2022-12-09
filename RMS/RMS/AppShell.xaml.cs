using RMS.ViewModels;
using RMS.Views;
using RMS.Views.Login;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RMS
{
    public partial class AppShell : Xamarin.Forms.Shell
    {       
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CriarLoginPage), typeof(CriarLoginPage));
        }

    }
}
