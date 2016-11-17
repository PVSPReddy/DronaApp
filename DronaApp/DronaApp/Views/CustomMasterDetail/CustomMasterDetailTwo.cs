using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class CustomMasterDetailTwo : ContentPage
	{
		public CustomMasterDetailTwo()
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

