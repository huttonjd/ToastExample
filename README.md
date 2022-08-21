# Xamarin Toast Example
This is an example of a simple Xamarin Toast for Android and iOS.

Android has Toast built-in, iOS we have to add code to iOS project to do the same function.

It uses an interface service called IToast that its corresponding Dependency Service implementation is in Android and iOS.

NOTE: Got most of the code from 
<a target="_blank" rel="noopener noreferrer" href="https://github.com/LeoAndo/xamarin-forms-toast-snackbar-samples/tree/main/DependencyServiceToastSample">LeoAndo's DependencyServiceToastSample</a>

## What are the items that make this work

Item | Description | Code Location
---- | ----------- | -------------
ToastHelper | Helper class to make the call to DependentServices | ToastExample->Helpers->ToastHelper.cs (Shared)
IToast | Main interface  | ToastExample->Services->IToast.cs (Shared)
ToastAndroid | Android Service that is doing the work on Android | ToastExample.Android->Services->ToastAndroid.cs
ToastIOS | iOS Service that is doing the work on iOS | ToastExample.iOS->Services->ToastIOS.cs

## How to register IToast service 

### Android
In _Android_ code base,Open __MainActivity.cs__ and add to __OnCreate__ function before __LoadApplication__ call
```c#
//Register Toast 
global::Xamarin.Forms.DependencyService.Register<ToastAndroid>();
```

### iOS
No register is required due to at before namespace in __ToastIOS.cs__ before 
```c#
[assembly: Xamarin.Forms.Dependency(typeof(ToastIOS))]
```

## Code

### ToastHelper.cs
```c#
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
```

### IToast.cs
```c#
namespace ToastExample.Services
{
    public interface IToast
    {
        void Show(string message);
    }
}
```

### ToastAndroid.cs
```c#
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
```

### ToastIOS.cs
```c#
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
```