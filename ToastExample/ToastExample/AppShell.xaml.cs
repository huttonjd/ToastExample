using System;
using System.Collections.Generic;
using ToastExample.ViewModels;
using ToastExample.Views;
using Xamarin.Forms;

namespace ToastExample
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
