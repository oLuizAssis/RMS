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
        public AppShell(bool logado)
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CriarLoginPage), typeof(CriarLoginPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ModalSeletorProduto), typeof(ModalSeletorProduto));

            if (logado)
            {
                // Defina aqui a página que deseja tornar principal quando o usuário estiver logado
                // Neste exemplo, estou usando a página ItemDetailPage
                CurrentItem = new ShellItem
                {
                    Route = "AboutPage",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                    {
                        new ShellSection
                        {
                            Items =
                            {
                                new ShellContent
                                {
                                    ContentTemplate = new DataTemplate(() => new AboutPage())
                                }
                            }
                        }
                    }
                };
            }
            else
            {
                // Defina aqui a página que deseja tornar principal quando o usuário NÃO estiver logado
                // Neste exemplo, estou usando a página AboutPage
                CurrentItem = new ShellItem
                {
                    Route = "CriarLoginPage",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items = 
                    {   
                        new ShellSection
                        { 
                            Items = 
                            {
                                new ShellContent
                                {
                                    ContentTemplate = new DataTemplate(() => new CriarLoginPage())
                                }
                            }
                        }
                    }
                };
            }
        }

    }
}
