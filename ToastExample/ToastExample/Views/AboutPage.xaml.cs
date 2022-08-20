using System;
using System.ComponentModel;
using ToastExample.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToastExample.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ToastHelper.Show("This is a toast message");
        }
    }
}