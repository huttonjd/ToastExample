using System.ComponentModel;
using ToastExample.ViewModels;
using Xamarin.Forms;

namespace ToastExample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}