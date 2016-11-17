using System;

using Xamarin.Forms;

namespace DronaApp.Droid
{
	public class MasterDetailsOneRender : ContentPage
	{
		public MasterDetailsOneRender()
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

