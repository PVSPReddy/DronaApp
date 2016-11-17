using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterDetailsTwo : ContentPage
	{
		public MasterDetailsTwo()
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

