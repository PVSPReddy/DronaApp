using System;

using Xamarin.Forms;

namespace MasterDetailEx
{
	public class GreenPage : ContentPage
	{
		public GreenPage()
		{
			CustomProperties cp = new CustomProperties();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			#region region for title bar
			var imgMenuBar = new Image
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Source = Device.OnPlatform("Menu.png", "Menu.png", "Menu.png"),
				VerticalOptions = LayoutOptions.Center,
			};
			var bvTransperant = new BoxView
			{
				HeightRequest = Device.OnPlatform(20, 0, 0),
				BackgroundColor = Color.Teal,
			};
			var titles = new Label
			{
				Text = "HOME",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.Center,

			};
			var stackHeader = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Teal,
				HeightRequest = (screenHeight / 100) * 10,
				WidthRequest = screenWidth,
				VerticalOptions = LayoutOptions.Start,
				Spacing = 0,
				Children = { imgMenuBar, titles }
			};
			TapGestureRecognizer menuTap = new TapGestureRecognizer();
			menuTap.NumberOfTapsRequired = 1;
			menuTap.Tapped += (object sender, EventArgs e) =>
			{
				Content = null;
				var pagers = cp.MainAppPage as ContentPage;
				Content = pagers.Content;
				//var parentPage = (MasterDetailPage)this.Parent;
				//parentPage.IsPresented = (parentPage.IsPresented == false) ? true : false;
			};
			if (Device.OS == TargetPlatform.Android)
			{
				imgMenuBar.GestureRecognizers.Add(menuTap);
			}
			else
			{
				titles.GestureRecognizers.Add(menuTap);
			}
			#endregion
			#region body
			StackLayout bodyHolder = new StackLayout()
			{
				Children = {
					new Label {
						Text = "Green",
						FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
						HorizontalOptions = LayoutOptions.Center
					},
					new BoxView {
						Color = Color.Green,
						WidthRequest = 200,
						HeightRequest = 200,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
			#endregion
			#region
			StackLayout holder = new StackLayout()
			{
				Children = { stackHeader, bodyHolder },
				HeightRequest = screenHeight,
				WidthRequest = screenWidth,
				BackgroundColor = Color.White
			};
			Content = holder;
			#endregion
		}
	}
}


