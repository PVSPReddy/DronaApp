using System;

using Xamarin.Forms;

namespace DronaApp.iOS
{
	public class MasterDetailsTwoRender : ContentPage
	{
		public MasterDetailsTwoRender()
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

