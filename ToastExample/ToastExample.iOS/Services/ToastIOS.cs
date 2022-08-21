using Foundation;
using System;
using UIKit;
using CoreGraphics;
using ToastExample.Services;
using ToastExample.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ToastIOS))]
namespace ToastExample.iOS.Services
{
    public class ToastIOS : IToast
    {
        public static void Init()
        {

        }
        public void Show(string message)
        {
            var toast = new Toast();
            toast.Show(UIApplication.SharedApplication.KeyWindow.RootViewController.View, message);
        }
    }

    class Toast
    {
        // Toast View
        UIView _view;
        // Toast message
        UILabel _label;
        // Toast size
        int _margin = 30;
        int _height = 40;
        int _width = 200; // orginally was 150;

        NSTimer _timer = null;

        public Toast()
        {
            // create Toast View
            _view = new UIView(new CGRect(0, 0, 0, 0))
            {
                BackgroundColor = UIColor.Gray,
            };
            _view.Layer.CornerRadius = (nfloat)20.0;
            //  create Toast Label
            _label = new UILabel(new CGRect(0, 0, 0, 0))
            {
                TextAlignment = UITextAlignment.Center,
                TextColor = UIColor.White
            };
            _view.AddSubview(_label);

        }

        public void Show(UIView parent, string message)
        {
            if (_timer != null)
            {
                _timer.Invalidate();
                _view.RemoveFromSuperview();
            }

            _view.Alpha = (nfloat)0.7;

            _view.Frame = new CGRect(
                (parent.Bounds.Width - _width) / 2,
                parent.Bounds.Height - _height - _margin,
                _width,
                _height);

            _label.Frame = new CGRect(0, 0, _width, _height);
            _label.Text = message;

            parent.AddSubview(_view);


            var wait = 10;
            _timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromMilliseconds(70), delegate
            {

                if (_view.Alpha <= 0)
                {
                    _timer.Invalidate();
                    _view.RemoveFromSuperview();
                }
                else
                {
                    if (wait > 0)
                    {
                        wait--;
                    }
                    else
                    {
                        _view.Alpha -= (nfloat)0.05;
                    }
                }
            });
        }
    }
}