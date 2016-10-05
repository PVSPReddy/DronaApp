using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class GalleryIntroduction : ContentPage
	{
		CustomProperties cp = new CustomProperties();
		public GalleryIntroduction()
		{
			InitializeComponent();
			holder.HeightRequest = cp.AppScreenHeight;
			holder.WidthRequest = cp.AppScreenWidth;
			header.HeightRequest = cp.AppHeaderHeight;
			header.WidthRequest = cp.AppHeaderWidth;
			Title = ""; //mandatory
		}
		public void MenuClicked(object sender, EventArgs e)
		{
			try
			{
				//if (navigate == false)
				//{
				//	menu.Text = ">";
				//	navigate = true;
				//}
				//else
				//{
				//	menu.Text = "<";
				//	navigate = false;
				//}
				/*menu.BackgroundColor = Color.FromRgba(225, 225, 225, 0.5);
				await Task.Delay(1);
				menu.BackgroundColor = Color.Transparent;*/
				var makeThisAsMenu = (MasterDetailPage)this.Parent;
				makeThisAsMenu.IsPresented = (makeThisAsMenu.IsPresented == false) ? true : false;
				makeThisAsMenu.IsPresentedChanged += async (object _sender, EventArgs _e) =>
				{
					if (makeThisAsMenu.IsPresented)
					{
						menu.Text = "<";
						await DisplayAlert("Alert", "got true value baby", "cancel");
						//await boxanime.LayoutTo(new Rectangle((screenwd / 3.8), (screenht / 3), (screenwd / 2.09), (screenht / 3.5)), 0, null);
					}
					else
					{
						menu.Text = ">";
						await DisplayAlert("Alert", "got false value baby", "cancel");
						//await boxanime.LayoutTo(new Rectangle((screenwd / 3.8), (screenht / 3), (screenwd / 2.09), (screenht / 3.5)), 0, null);
					}
				};
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


		public void movefurtherClicked(object sender, EventArgs e)
		{
			try
			{
				Navigation.PushModalAsync(new MyImageDisplay());
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


		public void goBackClicked(object sender, EventArgs e)
		{
			try
			{
				Navigation.PopModalAsync(true);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}
