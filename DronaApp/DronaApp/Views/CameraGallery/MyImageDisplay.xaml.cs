using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MyImageDisplay : ContentPage
	{
		ICameraGallery _mediaService;
		public MyImageDisplay()
		{
			CustomProperties cp = new CustomProperties();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			InitializeComponent();
			_mediaService = DependencyService.Get<ICameraGallery>();
			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenWidth;
		}
		public void cameraClicked(object sender, EventArgs e)
		{
			try
			{
				_mediaService.CaptureImage(this);
				//DependencyService.Get<ICameraGallery>().CaptureImage(this);
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
				//DependencyService.Get<ICameraGallery>().ShowSelectedImage(this);
				_mediaService.ShowSelectedImage(this);
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
		public void ShowImageIOS(string imagePath)
		{
			myImage.Source = ImageSource.FromFile(imagePath);
		}
		public void ShowImageDroid(string imagePath)
		{
			myImage.Source = ImageSource.FromFile(imagePath);
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

