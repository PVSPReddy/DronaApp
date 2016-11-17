using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class CustomMasterDetailTwo : MasterDetailsTwo
	{
		public CustomMasterDetailTwo()
		{
			Title = "";
			Icon = null; ;
			this.IsGestureEnabled = false;
			NavigationPage.SetHasNavigationBar(this, false);

			Application.Current.Properties["ParentPage"] = this;

			Master = new MastersPage();
			Detail = new BluePage() { BackgroundColor = Color.White, };
		}
	}
}

