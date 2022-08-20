using System;
using ToastExample.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ToastExample.Helpers
{
    public class ToastHelper
    {
        public static void Show(String Message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                IToast iToast = DependencyService.Get<IToast>();
                if (iToast != null)
                {
                    iToast.Show(Message);
                }
            });
        }
    }
}

