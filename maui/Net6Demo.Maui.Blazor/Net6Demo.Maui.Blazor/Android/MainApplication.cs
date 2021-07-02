using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;

namespace Net6Demo.Maui.Blazor
{
	[Application]
	public class MainApplication : MauiApplication<Startup>
	{
		public MainApplication(IntPtr handle, JniHandleOwnership ownership)
			: base(handle, ownership)
		{
		}
	}
}