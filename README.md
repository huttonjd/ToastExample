# Xamarin Toast Example
This is an example of a simple Xamarin Toast for Android and iOS.

It uses an interface service called IToast that its corresponding Dependency Service implementation is in Android and iOS.

## What are the items that make this work

Item | Description | Code Location
---- | ----------- | -------------
ToastHelper | Helper class to make the call to DependentServices | ToastExample->Helpers->ToastHelper.cs (Shared)
IToast | Main interface  | ToastExample->Services->IToast.cs (Shared)
ToastAndroid | Android Service that is doing the work on Android | ToastExample.Android
->Services->ToastAndroid.cs
ToastIOS | iOS Service that is doing the work on iOS | ToastExample.iOS
->Services->ToastIOS.cs



