using System;
using System.Collections.Generic;
using System.ComponentModel;
using ToastExample.Models;
using ToastExample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToastExample.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}