using System;
using Xamarin.Forms;

namespace FormExample
{
	public class AbsoluteLayoutExample : ContentPage
	{
		public AbsoluteLayoutExample ()
		{
			AbsoluteLayout absoluteLayout = new AbsoluteLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Black,
			};
			Content = absoluteLayout;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			// more views here
			Label firstLabel = new Label {
				Text = "FirstLabel",
				BackgroundColor = Color.White,
				TextColor = Color.Blue
			};

			absoluteLayout.Children.Add (firstLabel, new Rectangle (0, 0, 
				AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize), 
				AbsoluteLayoutFlags.PositionProportional);

			Label secondLabel = new Label {
				Text = "Second Label", 
				BackgroundColor = Color.White,
				TextColor = Color.Red,
				HorizontalTextAlignment = TextAlignment.Center
			};

			absoluteLayout.Children.Add (secondLabel);
			AbsoluteLayout.SetLayoutFlags (secondLabel, AbsoluteLayoutFlags.XProportional | AbsoluteLayoutFlags.WidthProportional);
			AbsoluteLayout.SetLayoutBounds (secondLabel, new Rectangle (0.5, 100, 0.75,
				AbsoluteLayout.AutoSize));

			Label thirdLabel = new Label {
				Text = "Third Label",
				BackgroundColor = Color.White,
				TextColor = Color.Green
			};

			absoluteLayout.Children.Add (thirdLabel, new Rectangle (1, 1, 
				AbsoluteLayout.AutoSize, 0.33), 
				AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional);


			firstLabel.Text += "\nFlags: PositionProportional\n" +
				"Bounds: (0, 0, AutoSize, AutoSize)";

			secondLabel.Text += "\nFlags: XProportional | WidthProportional\n" +
				"Bounds: (0.5, 100, 0.75, AutoSize)";

			thirdLabel.Text += "\nFlags: PositionProportional | HeightProportional\n" +
				"Bounds: (1, 1, AutoSize, 0.33)";
		}
	}
}

