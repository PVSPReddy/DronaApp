using System;
namespace DronaApp
{
	public interface ICameraGallery
	{
		void CaptureImage(MyImageDisplay _myimagedisplay);

		void ShowSelectedImage(MyImageDisplay _myimagedisplay);
	}
}

