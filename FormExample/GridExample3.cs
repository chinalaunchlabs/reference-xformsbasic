using System;
using Xamarin.Forms;

namespace FormExample
{
	public class GridExample3 : ContentPage
	{
		/* 
		 * Grid with dynamic number of rows and columns
		 */ 
		public GridExample3 ()
		{
//
			Color[] colors = {
				Color.Red, 
				Color.FromRgb(232, 126, 0),	// orange
				Color.Yellow,
				Color.Green, 
				Color.Blue,
				Color.Aqua,
				Color.Purple
			};
			Grid grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = new RowDefinitionCollection(),
				ColumnDefinitions = new ColumnDefinitionCollection(),
				RowSpacing = 0,
				ColumnSpacing = 1
			};

			Content = grid;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			int rows = 20, columns = colors.Length;

			for (int r = 0; r < rows; r++) {
				grid.RowDefinitions.Add (new RowDefinition {Height = new GridLength(1, GridUnitType.Star)} );
			}

			for (int c = 0; c < columns; c++) {
				grid.ColumnDefinitions.Add (new ColumnDefinition {Width = new GridLength (1, GridUnitType.Star) });
			}

			for (int r = 0; r < rows; r++) {
				for (int c = 0; c < columns; c++) {
					float multiplier = 1-((float)r / rows);
					Color temp = Color.FromRgb(colors[c].R * multiplier, colors[c].G * multiplier, colors[c].B * multiplier);
					string text = r + ", " + c;
					grid.Children.Add (new Label {
//						Text = text,
						TextColor = Color.White,
						BackgroundColor = temp
					}, c, r);
				}
			}
		}
	}
}

