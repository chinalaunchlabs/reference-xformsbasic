using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FormExample
{
	public class ListItem {
		public string Title { get; set; }
		public string Description { get; set; }
		public string Price { get; set; }
	}
	public class ListItemCell: ViewCell
	{
		public ListItemCell ()
		{
			Label titleLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Black
			};
			titleLabel.SetBinding (Label.TextProperty, "Title");

			Label descLabel = new Label {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				TextColor = Color.Gray
			};
			descLabel.SetBinding (Label.TextProperty, "Description");

			Label priceLabel = new Label {
				HorizontalOptions = LayoutOptions.End,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				TextColor = Color.Teal,
			};
			priceLabel.SetBinding (Label.TextProperty, "Price");

			var button = new Button {
				Text = "Buy Now",
				HorizontalOptions = LayoutOptions.EndAndExpand
			};
			button.SetBinding (Button.CommandParameterProperty, new Binding ("."));
			button.Clicked += (sender, e) =>
			{
				var b = (Button)sender;
				var item = (ListItem)b.CommandParameter;
				((ContentPage) ((StackLayout) ((ListView)((StackLayout)((StackLayout)b.ParentView).ParentView).ParentView).ParentView).ParentView).DisplayAlert("Clicked", item.Title.ToString() + " button was clicked", "OK");
			};

			StackLayout titleAndDescLayout = new StackLayout {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = {
					titleLabel,
					descLabel
				}
			};
					
			StackLayout viewButton = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Orientation = StackOrientation.Horizontal,
				WidthRequest = 260,
				Children = { priceLabel, button }
			};

			StackLayout wholeLayout = new StackLayout {
				Children = {
					titleAndDescLayout,
					viewButton
				},
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(25, 10, 55, 15),
				Orientation = StackOrientation.Horizontal
			};

			View = wholeLayout;

		}
	}

	public class Group: List<ListItem>
	{
		public string Key { get; set; }
		public Group (string key, List<ListItem> items) {
			Key = key;
			foreach (var item in items) {
				this.Add (item);
			}
		}
	}

	public class HeaderCell: ViewCell 
	{
		public HeaderCell() {
			this.Height = 40;
			var title = new Label {
				FontSize = 16,
				TextColor = Color.Black,
				VerticalOptions = LayoutOptions.Center
			};
			title.SetBinding (Label.TextProperty, "Key");

			View = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 40,
				BackgroundColor = Color.Aqua,
				Padding = 5,
				Orientation = StackOrientation.Horizontal,
				Children = {
					title
				}
			};
		}

	}

	public class ListViewStrings : ContentPage
	{
		public ListViewStrings ()
		{
			Label debug = new Label {
				Text = "Debug text here",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.White,
				BackgroundColor = Color.Red
			};

			List<ListItem> items = new List<ListItem> () {
				new ListItem {Title = "Uno", Description = "So much depends upon", Price = "PHP 234" },
				new ListItem {Title = "Dos", Description = "A red wheel barrow", Price = "PHP 453"},
				new ListItem {Title = "Tres", Description = "Glazed with rain water", Price = "PHP 3434"},
				new ListItem {Title = "Quatro", Description = "Beside the white chickens", Price = "PHP 123"},
			};

			List<Group> itemsGrouped = new List<Group> () {
				new Group ("Important", items),
				new Group ("Not so important", new List<ListItem> {
					new ListItem {Title = "Lala", Description = "Xamarin", Price = "PHP 0"}
				})
			};


			ListView listView = new ListView {
				ItemsSource = itemsGrouped,
				RowHeight = 80,
				IsGroupingEnabled = true,
				GroupDisplayBinding = new Binding("Key"),
				GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell)),
				HasUnevenRows = true
			};
			listView.ItemTemplate = new DataTemplate (typeof(ListItemCell));

			listView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				ListItem item = (ListItem) e.Item;
				debug.Text = "Picked " + item.Title + " with description: " + item.Description;
			};

			StackLayout stackLayout = new StackLayout {
				Children = {
					debug,
					listView
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = stackLayout;
			Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 10);

		}
	}
}

