using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterDetailsPages : ContentPage
	{
		public MasterDetailsPages()
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

