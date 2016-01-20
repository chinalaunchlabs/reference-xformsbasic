using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormExample
{
	public class Controls : ContentPage
	{
		Label eventValue, pageValue;

		public Controls ()
		{
			System.Diagnostics.Debug.WriteLine ("Controls:: Hello");

			eventValue = new Label {
				Text = "Value in Handler"
			};
			pageValue = new Label {
				Text = "Value in Page"
			};

			Picker picker = new Picker {
				Title = "Option",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var options = new List<string> {
				"First",
				"Second",
				"Third",
				"Fourth"
			};

			foreach (string optionName in options) {
				picker.Items.Add (optionName);
			}
			picker.SelectedIndexChanged += (sender, e) => {
				System.Diagnostics.Debug.WriteLine("Picked " + picker.Items[picker.SelectedIndex]);
				pageValue.Text = picker.Items[picker.SelectedIndex];
			};

			DatePicker datePicker = new DatePicker {
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			datePicker.DateSelected += (object sender, DateChangedEventArgs e) => {
				eventValue.Text = e.NewDate.ToString();
				pageValue.Text = datePicker.Date.ToString();
			};

			TimePicker timePicker = new TimePicker {
				Format = "T",
				VerticalOptions = LayoutOptions.Center
			};
			timePicker.PropertyChanged += (sender, e) => {
				if (e.PropertyName == TimePicker.TimeProperty.PropertyName) {
					pageValue.Text = timePicker.Time.ToString();
				}
			};

			Stepper stepper = new Stepper {
				Minimum = 0,
				Maximum = 10,
				Increment = 1,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			// Alternatively
			// public Stepper(min, max, start, increment)
			// Stepper stepper = new Stepper(0, 10, 0, 1);
			stepper.ValueChanged += (sender, e) => {
				eventValue.Text = String.Format("Stepper value is {0:F1}", e.NewValue);
				pageValue.Text = stepper.Value.ToString();
			};

			Slider slider = new Slider {
				Minimum = 0,
				Maximum = 100,
				WidthRequest = 100,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			slider.ValueChanged += (sender, e) => {
				eventValue.Text = String.Format("Slider val is {0:F1}", e.NewValue);
				pageValue.Text = slider.Value.ToString();
			};

			// Layout
			StackLayout stackLayout = new StackLayout {
				Children = {
					eventValue,
					pageValue,
					picker,
					datePicker,
					timePicker,
					stepper,
					slider
				},
				HorizontalOptions = LayoutOptions.Center,
			};

			Content = stackLayout;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

		}
	}
}

