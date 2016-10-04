using System;

using Xamarin.Forms;

namespace DronaApp.Droid
{
	public class IEmailService : ContentPage
	{
		public IEmailService()
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


