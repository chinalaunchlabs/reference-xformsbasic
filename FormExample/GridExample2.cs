using System;
using Xamarin.Forms;

namespace FormExample
{
	public class GridExample2 : ContentPage
	{
		public GridExample2 ()
		{
			Grid grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength (1, GridUnitType.Star) },
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
				},
				RowSpacing = 0,
				BackgroundColor = Color.FromRgb(0.9, 0.9, 0.9)
			};

			Content = grid;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			grid.Children.Add (new Label {
				Text = "щ(ºДºщ)",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				BackgroundColor = Color.FromRgb(255, 189, 140),
				TextColor = Color.White,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
			}, 2, 3, 3, 4);

			grid.Children.Add (new Label {
				Text = "This is an example of spanning.",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				BackgroundColor = Color.FromRgb(218, 255, 177),
				TextColor = Color.FromRgb(147, 217, 105),
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
			}, 0, 3, 2, 3);

			grid.Children.Add (new Image {
				Source = "http://images5.fanpop.com/image/photos/30700000/Calvin-calvin-and-hobbes-30770682-200-200.jpg",
				Aspect = Aspect.AspectFill
			}, 0, 1, 1, 2);


			grid.Children.Add (new Image {
				Source = "http://www.centralcomics.com/wp-content/uploads/2014/02/CALVIN-HOBBES-Pureness.png",
				Aspect = Aspect.AspectFill,
			}, 0, 2, 3, 6);

		}
	}
}

