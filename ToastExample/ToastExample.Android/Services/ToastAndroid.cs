using Android.App;
using Android.Widget;
using ToastExample.Services;

namespace ToastExample.Droid.Services
{
    public class ToastAndroid : IToast
    {
        Toast m_currentToast = null;


        public ToastAndroid()
        {
        }
        public void Show(string message)
        {
            m_currentToast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            m_currentToast.Show();
        }

        public void Cancel()
        {
            if (m_currentToast != null)
            {
                m_currentToast.Cancel();
            }
        }
    }
}