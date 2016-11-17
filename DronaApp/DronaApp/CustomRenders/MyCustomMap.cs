using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MyCustomMap : ContentPage
	{
		public MyCustomMap()
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

