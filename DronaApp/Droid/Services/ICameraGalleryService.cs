using System;
using DronaApp.Droid;
using Xamarin.Forms;

[assembly : Dependency(typeof(ICameraGalleryService))]
namespace DronaApp.Droid
{
	public class ICameraGalleryService : ICameraGallery
	{
		public ICameraGalleryService(){}

		public bool CaptureImage(MyImageDisplay _myimagedisplay)
		{
			throw new NotImplementedException();
		}

		public bool ShowSelectedImage(MyImageDisplay _myimagedisplay)
		{
			throw new NotImplementedException();
		}
	}
}


