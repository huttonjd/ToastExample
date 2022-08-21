# Xamarin Toast Example
This is an example of a simple Xamarin Toast for Android and iOS.

Android has Toast built-in, iOS we have to add code to iOS project to do the same function.

It uses an interface service called IToast that its corresponding Dependency Service implementation is in Android and iOS.

NOTE: Got most of the code from [LeoAndo's DependencyServiceToastSample](https://github.com/LeoAndo/xamarin-forms-toast-snackbar-samples/tree/main/DependencyServiceToastSample)

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

### ToastHelper
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
