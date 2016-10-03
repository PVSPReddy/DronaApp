using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class MasterPage_ListView : MasterDetailPage
	{
		public MasterPage_ListView()
		{
			this.Icon = null; //mandatory field
			this.Title = "";  //mandatory field
			this.IsGestureEnabled = false;


			NavigationPage.SetHasNavigationBar(this, false); //mandatory field


			Application.Current.Properties["ParentPage"] = this;

			Master = new MasterPage_LV_Menu() { };
			Detail = new MasterPage_LV_Detail() { BackgroundColor = Color.Teal };
		}
	}
}


