using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class DisplayAllWorkers : ContentPage
	{
		DataBaseMethods dbms;
		public DisplayAllWorkers()
		{
			dbms = new DataBaseMethods();
			var ms_details = dbms.userRetrived_Info();
			CustomProperties cp = new CustomProperties();
			InitializeComponent();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;

			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenHeight;
			back.WidthRequest = (screenWidth * 3) / 5;


			EmployeeDetails.ItemsSource = ms_details;
			EmployeeDetails.RowHeight = Convert.ToInt32((screenWidth * 1.5) / 3);

		}
		public async void BackClicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new MyFriendsRegistration());

		}
	}
}
