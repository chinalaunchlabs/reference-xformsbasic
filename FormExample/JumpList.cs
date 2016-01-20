using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormExample
{

	public class JumpList: ContentPage
	{
		public JumpList ()
		{
			List<Group> itemsGroup = Populate ();

			ListView listView = new ListView {
				ItemsSource = itemsGroup,
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Key"),
				GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell)),
				HasUnevenRows = true,
				IsPullToRefreshEnabled = true,
				GroupShortNameBinding = new Binding("Key"),
			};
			listView.ItemTemplate = new DataTemplate (typeof(TextCell));
			listView.ItemTemplate.SetBinding (TextCell.TextProperty, "Title");
			listView.ItemTemplate.SetBinding (TextCell.DetailProperty, "Description");

			Content = listView;
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);
		}

		private List<Group> Populate() {
			int limit = 5;
			List<Group> group = new List<Group> ();
			List<ListItem> temp = new List<ListItem> ();

			for (char key = 'A'; key <= 'Z'; key++) {
				for (int i = 0; i < limit; i++) {
					temp.Add (new ListItem { Title = key + i.ToString(), Description = i.ToString(), Price = (i*100).ToString() });
				}
				group.Add(new Group(key.ToString(), temp));
				temp.Clear ();
			}

			return group;
		}
	}
}

