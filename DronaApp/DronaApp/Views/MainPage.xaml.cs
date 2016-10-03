using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MainPage : ContentPage
	{
		CustomProperties cp = new CustomProperties();
		public MainPage()
		{
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			InitializeComponent();

			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenWidth;
		}
		public void elmdp_Clicked(object sender, EventArgs e)
		{
			Application.Current.MainPage = new MasterPage_ListView();
		}

		public void esmdp_Clicked(object sender, EventArgs e)
		{

		}
			
	}
}

