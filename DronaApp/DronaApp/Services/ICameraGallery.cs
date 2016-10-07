using System;
namespace DronaApp
{
	public interface ICameraGallery
	{
		bool CaptureImage(MyImageDisplay _myimagedisplay);

		bool ShowSelectedImage(MyImageDisplay _myimagedisplay);
	}
}

