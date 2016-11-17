using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterDetailsPages : MasterDetailsOne
	{
		public MasterDetailsPages()
		{
			Title = "";
			Icon = null;;
			this.IsGestureEnabled = false;
			this.DrawerWidth = 200;
			NavigationPage.SetHasNavigationBar(this, false);

			Application.Current.Properties["ParentPage"] = this;

			Master = new MastersPage();
			Detail = new BluePage() { BackgroundColor = Color.White, };
		}
	}
}

