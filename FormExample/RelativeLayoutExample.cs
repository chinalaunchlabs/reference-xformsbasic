using System;
using Xamarin.Forms;

namespace FormExample
{
	public class RelativeLayoutExample : ContentPage
	{
		public RelativeLayoutExample ()
		{
			RelativeLayout relativeLayout = new RelativeLayout ();
			Content = relativeLayout;
			Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			Label upperLeft = new Label {
				Text = "Upper Left",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			relativeLayout.Children.Add (upperLeft,
				Constraint.Constant (0),
				Constraint.Constant (0));

			Label halfwayDown = new Label {
				Text = "Half way down and across",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
			};

			relativeLayout.Children.Add (halfwayDown,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
				 	return parent.Height / 2;
				})
			);

			BoxView boxView = new BoxView {
				Color = Color.Accent,
				WidthRequest = 150,
				HeightRequest = 150,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			relativeLayout.Children.Add (
				boxView,
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Height / 2;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Width / 2;
					}),
				Constraint.RelativeToParent((parent) =>
					{
						return parent.Height / 2;
					})
			);

			Label below = new Label {
				Text = "Below Upper Left",
				FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label))
			};

			relativeLayout.Children.Add (
				below,
				Constraint.Constant(0),
				Constraint.RelativeToView(upperLeft, (parent, sibling) => 
				{
						return sibling.Y + sibling.Height;
				})
			);

		}
	}
}

