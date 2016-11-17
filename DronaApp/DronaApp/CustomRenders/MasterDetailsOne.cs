using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterDetailsOne : ContentPage
	{
		public MasterDetailsOne()
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

