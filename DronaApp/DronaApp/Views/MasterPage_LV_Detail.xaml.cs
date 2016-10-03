using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class MasterPage_LV_Detail : ContentPage
	{
		CustomProperties cp = new CustomProperties();
		Label navigator;
		public MasterPage_LV_Detail()
		{
			InitializeComponent();
			Title = "";
			#region header starts from here
			bool navigate = false;
			navigator = new Label()
			{
				Text = ">",
				TextColor=Color.Maroon,
				FontSize=Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				//Source = ImageSource.FromFile("Menu.png"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};
			TapGestureRecognizer menu_clicked = new TapGestureRecognizer();
			menu_clicked.NumberOfTapsRequired = 1;
			menu_clicked.Tapped += (object sender, EventArgs e) =>
			{
				try
				{
					if (navigate == false)
					{
						navigator.Text = ">";
						navigate = true;
					}
					else
					{
						navigator.Text = "<";
						navigate = false;
					}
					/*menu.BackgroundColor = Color.FromRgba(225, 225, 225, 0.5);
					await Task.Delay(1);
					menu.BackgroundColor = Color.Transparent;*/
					var makeThisAsMenu = (MasterDetailPage)this.Parent;
					makeThisAsMenu.IsPresented = (makeThisAsMenu.IsPresented == false) ? true : false;
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
				}
			};
			navigator.GestureRecognizers.Add(menu_clicked);
			Label masterMenu = new Label()
			{
				Text = "My Home",
				TextColor = Color.Red,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};
			StackLayout header = new StackLayout()
			{
				WidthRequest = cp.AppHeaderWidth,
				HeightRequest = cp.AppHeadderHeight,
				BackgroundColor = Color.Blue,
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center,
				Children = { navigator, masterMenu }
			};

			#endregion

			Content = header;
		}
	}
}

