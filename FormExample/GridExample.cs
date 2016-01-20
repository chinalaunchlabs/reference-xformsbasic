using System;
using Xamarin.Forms;

namespace FormExample
{
	public class GridExample : ContentPage
	{
		public GridExample ()
		{
			Grid grid1 = new Grid {
				VerticalOptions = LayoutOptions.Fill,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},
				BackgroundColor = Color.Lime,
				ColumnSpacing = 10
			};

			Grid grid2 = new Grid {
				VerticalOptions = LayoutOptions.Fill,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition(),
					new ColumnDefinition(),
					new ColumnDefinition(),
					new ColumnDefinition(),
				},
				BackgroundColor = Color.Aqua,
				ColumnSpacing = 20,
			};

			Grid grid3 = new Grid {
				VerticalOptions = LayoutOptions.Fill,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) }
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
				},
				BackgroundColor = Color.Yellow,
				ColumnSpacing = 30
			};

			StackLayout stackLayout = new StackLayout {
				Children = {
					grid1,
					grid2,
					grid3
				},
				Spacing = 0
			};

			Content = stackLayout;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			// views
			grid1.Children.Add (new Label {
				Text = "col width\n" +
					"GridLength.Auto",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.8, 1, 0.8)
			}, 0, 0);

			grid1.Children.Add (new Label {
				Text = "I'm at 1, 0",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.6, 1, 0.6)
			}, 1, 0);

			grid1.Children.Add (new Label {
				Text = "I'm at 2, 0\n" +
					"moar text here\n" +
					"does this expand horizontally",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.4, 1, 0.4)
			}, 2, 0);

			grid1.Children.Add (new Label {
				Text = "Yes it does!",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.2, 1, 0.2)
			}, 3, 0);


			// grid2
			grid2.Children.Add (new Label {
				Text = "col width\n" +
					"GridLength.Star",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.2, 0.2, 1)
			}, 0, 0);

			grid2.Children.Add (new Label {
				Text = "I'm at 1, 0",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.4, 0.4, 1)
			}, 1, 0);

			grid2.Children.Add (new Label {
				Text = "Does this expand horizontally?",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.6, 0.6, 1)
			}, 2, 0);

			grid2.Children.Add (new Label {
				Text = "No it doesn't",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.8, 0.8, 1)
			}, 3, 0);

			// grid3
			grid3.Children.Add (new Label {
				Text = "height: 40, abs\n" +
					"width: 2, star",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.5, 0.2, 0.5)
			}, 0, 0);

			grid3.Children.Add (new Label {
				Text = "width = 1, star",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.5, 0.4, 0.5)
			}, 1, 0);

			grid3.Children.Add (new Label {
				Text = "width = 3, star",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.5, 0.6, 0.5)
			}, 2, 0);

			grid3.Children.Add (new Label {
				Text = "width = 1, star",
				VerticalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				BackgroundColor = Color.FromRgb(0.5, 0.8, 0.5)
			}, 3, 0);

		}

	}
}

