using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MyImageDisplay : ContentPage
	{
		ICameraGallery _mediaService;
		ICameraGalleryDroidSpl _mediaServiceAndroidSpl;
		public static MyImageDisplay mid;
		public MyImageDisplay()
		{
			CustomProperties cp = new CustomProperties();
			var screenHeight = cp.AppScreenHeight;
			var screenWidth = cp.AppScreenWidth;
			InitializeComponent();
			_mediaService = DependencyService.Get<ICameraGallery>();
			_mediaServiceAndroidSpl = DependencyService.Get<ICameraGalleryDroidSpl>();
			holder.HeightRequest = screenHeight;
			holder.WidthRequest = screenWidth;
			mid = this;

		}
		public void cameraClicked(object sender, EventArgs e)
		{
			try
			{
				
				//DependencyService.Get<ICameraGallery>().CaptureImage(this);
				if (androidpersonalSwitch.IsToggled == false)
				{
					_mediaService.CaptureImage(this);
				}
				else
				{
					if (Device.OS == TargetPlatform.Android)
					{
						_mediaServiceAndroidSpl.CaptureImageDroidSplOne(this);
					}
					else
					{
						_mediaService.CaptureImage(this);
					}
				}
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
				if (androidpersonalSwitch.IsToggled == false)
				{
					_mediaService.ShowSelectedImage(this);
				}
				else
				{
					if (Device.OS == TargetPlatform.Android)
					{
						_mediaServiceAndroidSpl.ShowSelectedImageDroidSplOne(this);
					}
					else 
					{
						_mediaService.ShowSelectedImage(this);
					}
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
		public void ShowImageIOS(string imagePath)
		{
			myImage.Aspect = Aspect.AspectFit;
			myImage.Source = ImageSource.FromFile(imagePath);
		}
		public void ShowImageDroid(string imagePath)
		{
			//Uri _uri = new Uri(imagePath);
			//myImage.Source = ImageSource.FromUri(_uri);
			myImage.Aspect = Aspect.AspectFit;
			myImage.Source = ImageSource.FromFile(imagePath);
			//myImage.Source = imagePath;
		}
		public void ShowImage(string imagePath)
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				myImage.Source = ImageSource.FromFile(imagePath);
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				//myImage.Source = ImageSource.FromStream(() =>
				//new 

				                                       //)
			}
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
	public class DataRetriver
	{
		
	}
}

