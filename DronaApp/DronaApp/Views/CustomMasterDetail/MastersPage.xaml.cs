using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MastersPage : ContentPage
	{
		public MastersPage()
		{
			InitializeComponent();
			Title = "Menus";
			CustomProperties cp = new CustomProperties();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			BackgroundColor = Color.Transparent;
			List<PageMenu> menuList = new List<PageMenu>()
			{
				new PageMenu{Title="BluePage0"},
				new PageMenu{Title="RedPage1"},
				new PageMenu{Title="GreenPage2"},
				new PageMenu{Title="MaroonPage3"},
				new PageMenu{Title="YellowPage4"},
				new PageMenu{Title="TealPage5"},
			};

			ListView menuDisplay = new ListView()
			{
				ItemsSource = menuList,
				HasUnevenRows = true,
				//WidthRequest = 40,
				BackgroundColor = Color.White,
				SeparatorVisibility = SeparatorVisibility.None,
				ItemTemplate = new DataTemplate(typeof(MenuHolder)),
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			menuDisplay.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
			{
				try
				{
					if (e.SelectedItem == null)
					{
						return;
					}
					var parentPage = (MasterDetailPage)this.Parent;
					var item = (PageMenu)e.SelectedItem;
					parentPage.IsPresented = false;

					switch (item.Title)
					{
						case "HomePage1":
							parentPage.Detail = new BluePage { BackgroundColor = Color.White };
							break;
						case "HomePage2":
							parentPage.Detail = new RedPage { BackgroundColor = Color.White };
							break;
						case "HomePage3":
							parentPage.Detail = new GreenPage { BackgroundColor = Color.White };
							break;
						case "HomePage4":
							parentPage.Detail = new MaroonPage { BackgroundColor = Color.White };
							break;
						case "HomePage5":
							parentPage.Detail = new YellowPage { BackgroundColor = Color.White };
							break;
						case "HomePage6":
							parentPage.Detail = new TealPage { BackgroundColor = Color.White };
							break;
					}

				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine("Error => " + ex.Message);
					System.Diagnostics.Debug.WriteLine("StackTrace => " + ex.StackTrace);
					var msg = ex.Message;
				}
				((ListView)sender).SelectedItem = null;
			};


			StackLayout holder = new StackLayout()
			{
				Padding = new Thickness(0, 20, 150, 0),
				Children = { menuDisplay },
				//HeightRequest = screenHeight,
				WidthRequest = 20,
				BackgroundColor = Color.Transparent
			};
			Content = holder;
		}
	}

	public class MenuHolder : ViewCell
	{
		public MenuHolder()
		{
			Label title = new Label()
			{
				TextColor = Color.Yellow,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			title.SetBinding(Label.TextProperty, "Title");
			StackLayout Menu = new StackLayout()
			{
				//Padding = new Thickness(0, 20, 150, 0),
				Children = { title },
				WidthRequest = 40,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Green
			};
			View = Menu;
		}
	}

	public class PageMenu
	{
		public string Title { get; set; }
	}
}