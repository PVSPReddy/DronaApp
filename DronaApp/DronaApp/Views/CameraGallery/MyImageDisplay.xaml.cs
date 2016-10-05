using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MyImageDisplay : ContentPage
	{
		public MyImageDisplay()
		{
			InitializeComponent();
			CustomProperties cp = new CustomProperties();
			holder.HeightRequest = cp.AppScreenHeight;
			holder.WidthRequest = cp.AppScreenWidth;
		}
		public void cameraClicked(object sender, EventArgs e)
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
		public void galleryClicked(object sender, EventArgs e)
		{
			try
			{
				
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}

