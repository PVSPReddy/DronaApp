using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class CustomProperties : ContentPage
	{
		public CustomProperties()
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


