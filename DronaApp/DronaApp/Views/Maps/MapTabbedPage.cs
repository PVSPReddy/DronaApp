using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MapTabbedPage : ContentPage
	{
		public MapTabbedPage()
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

