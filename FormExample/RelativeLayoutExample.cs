using System;
using Xamarin.Forms;

namespace FormExample
{
	public class RelativeLayoutExample : ContentPage
	{
		public RelativeLayoutExample ()
		{
			RelativeLayout relativeLayout = new RelativeLayout ();

			Label upperLeft = new Label {
				Text = "Upper Left",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

		}
	}
}

