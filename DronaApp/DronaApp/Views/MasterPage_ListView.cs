using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterPage_ListView : ContentPage
	{
		public MasterPage_ListView()
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


