using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class TemporaryListPage : ContentPage
	{
		public TemporaryListPage()
		{
			InitializeComponent();
			List<PageDetails> lvMenu = new List<PageDetails>()
			{
				(new PageDetails{pageName="Home Detail", imageSource=null, pageNavigation=typeof(MasterPage_LV_Detail)})
			};
			pageMenus.ItemsSource = lvMenu;
			pageMenus.ItemSelected += SelectPage;
		}
		void SelectPage(object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem != null)
				{
					var pageToOpen = (PageDetails)e.SelectedItem;
					if (pageToOpen != null)
					{
						var pageToOpen1 = (Page)Activator.CreateInstance(pageToOpen.pageNavigation);
						//Navigation.PushModalAsync(pageToOpen);
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			((ListView)sender).SelectedItem = null;
		}


		public void goBackClicked(object sender, EventArgs e)
		{
			try
			{
				Navigation.PopModalAsync(true);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}


	}
}

