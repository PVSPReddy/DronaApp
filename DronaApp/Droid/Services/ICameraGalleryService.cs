using System;

using Xamarin.Forms;

namespace DronaApp.Droid
{
	public class ICameraGalleryService : ContentPage
	{
		public ICameraGalleryService()
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


