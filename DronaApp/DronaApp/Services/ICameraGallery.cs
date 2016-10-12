using System;
namespace DronaApp
{
	public interface ICameraGallery
	{
		void CaptureImage(MyImageDisplay _myimagedisplay);

		void ShowSelectedImage(MyImageDisplay _myimagedisplay);

	}


	public interface ICameraGalleryDroidSpl
	{
		void CaptureImageDroidSplOne(MyImageDisplay _myimagedisplay);

		void ShowSelectedImageDroidSplOne(MyImageDisplay _myimagedisplay);
	}
}

