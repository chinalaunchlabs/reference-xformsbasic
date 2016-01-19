using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormExample
{
	public class ContentPageExample : ContentPage
	{
		public ContentPageExample ()
		{
			Label labelLarge = new Label {
				Text = "Label",
				FontSize = 40,
				HorizontalOptions = LayoutOptions.Center
			};

			Label labelSmall = new Label {
				Text = "This control is great for\n" +
					"displaying one or more\n" +
					"lines of text.",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center
			};

			Button button = new Button {
//				Text = "Make it so " + username.Text + "!",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Fill
			};

			button.Clicked += (sender, e) => {
				button.Text = "It is so!";
			};

			Entry username = new Entry {
				Placeholder = "Number 1",
				Text = "",
				VerticalOptions = LayoutOptions.Center,
				Keyboard = Keyboard.Text
			};
			username.Completed += (sender, e) => {
				SetButtonText(button, username);
			};
			SetButtonText (button, username);

			Entry password = new Entry {
				VerticalOptions = LayoutOptions.Center,
				Keyboard = Keyboard.Text,
				IsPassword = true
			};

			Image image = new Image {
				Source = "http://crowbarhighfive.com/wp-content/uploads/2014/05/Doge.png",
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Fill
			};

			StackLayout stackLayout = new StackLayout {
				Children = {
					labelLarge,
					labelSmall,
					image,
					username,
					password,
					button
				},
				HeightRequest = 100
			};

			ScrollView scrollView = new ScrollView {
				Content = stackLayout,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			// Gesture recognizers
			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += async (sender, e) => {
				image.Opacity = 0.5f;
				await Task.Delay(200);
				image.Opacity = 1;
			};
			image.GestureRecognizers.Add (tapGestureRecognizer);

			// Display the layout
			this.Content = scrollView;

			// Padding
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
		}

		private void SetButtonText(Button b, Entry name) {
			b.Text = "Make it so, " + (name.Text == "" ? name.Placeholder : name.Text) + "!";
		}
	}
}

