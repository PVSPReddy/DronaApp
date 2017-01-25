using System;

using Xamarin.Forms;

namespace DronaApp.iOS
{
	public class IGetLocationsService : ContentPage
	{
		public IGetLocationsService()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

