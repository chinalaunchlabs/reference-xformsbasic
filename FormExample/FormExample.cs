﻿using System;

using Xamarin.Forms;

namespace FormExample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
//			MainPage = new ContentPageExample ();
//			MainPage = new RelativeLayoutExample();
//			MainPage = new AbsoluteLayoutExample();
//			MainPage = new GridExample3();
//			MainPage = new Controls();
			MainPage = new JumpList();

//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms!"
//						}
//					}
//				}
//			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

