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
				(new PageDetails{pageName="Download File Example", imageSource=null, pageNavigation=typeof(DownloadInputDetails)}),
				(new PageDetails{pageName="DataBase Example", imageSource=null, pageNavigation=typeof(EmployeeRegistrationForm)}),
				(new PageDetails{pageName="CameraGallery Example", imageSource=null, pageNavigation=typeof(GalleryIntroduction)})
			};
			pageMenus.ItemsSource = lvMenu;
			pageMenus.ItemSelected += SelectPage;
		}

		#region this is a way to navigate from a list view to a page through selected item
		async void SelectPage(object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				if (e.SelectedItem != null)
				{
					var pageToOpen = (PageDetails)e.SelectedItem;
					var obtained = pageToOpen.pageNavigation;
					if (pageToOpen != null)
					{
						var pageToOpen1 = (Page)Activator.CreateInstance(pageToOpen.pageNavigation);
						await Navigation.PushModalAsync(pageToOpen1);
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			((ListView)sender).SelectedItem = null;
		}
		#endregion

		//#region
		//public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		//{
		//	if (value is bool)
		//	{
		//		return !(bool)value;
		//	}
		//		return value;
		//}

		//public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		//{
		//	throw new NotImplementedException();
		//}
		//#endregion

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


	//public class InvertBoolenConverter : IValueConverter
	//{

	//	#region IValueConverter implementation  these methods are used as universal convertors to convert to anything from any thing almost

	//	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	//	{
	//		if (value is bool)
	//		{

	//			return !(bool)value;
	//		}
	//		return value;
	//	}

	//	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	//	{
	//		throw new NotImplementedException();
	//	}

	//	#endregion
	//}
}

