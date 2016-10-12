using System;
using System.IO;
using System.Threading.Tasks;
using AssetsLibrary;
using Foundation;
using DronaApp.iOS;
using UIKit;
using Xamarin.Forms;

[assembly : Dependency(typeof(ICameraGalleryService))]
namespace DronaApp.iOS
{
	public class ICameraGalleryService : ICameraGallery
	{
		public ICameraGalleryService(){}



		public void CaptureImage(MyImageDisplay _myimagedisplay)
		{
			try
			{
				var parent = UIApplication.SharedApplication.KeyWindow.RootViewController;
				var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera};
				parent.PresentViewController(imagePicker, true, null);
				imagePicker.TakePicture();
				//(this, (obj)=>
				//{
				//});
				imagePicker.FinishedPickingMedia += (sender, e) =>
				{
					var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tmp.png");
					var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
					#region
					image.AsPNG().Save(filepath, false);
					var path = filepath;

					//mid.ShowImage(path);
					#endregion


					#region
					var metadata = (NSDictionary)e.Info.ObjectForKey(new NSString("UIImagePickerControllerMediaMetadata"));
					ALAssetsLibrary library = new ALAssetsLibrary();
					library.WriteImageToSavedPhotosAlbum(image.CGImage, metadata, (NSUrl arg1, NSError arg2) =>
					{
						var paths = arg1.ToString();
					});
					//library.WriteImageToSavedPhotosAlbum(photo.CGImage, meta, (assetUrl, error)
					#endregion


					/*#region
                    var imagetoalbum = UIImage.FromFile(path);
                    imagetoalbum.SaveToPhotosAlbum((UIImage image, NSError error) => 
                    {
                        var o = image;
                    });
                    #endregion*/


					//_myimagedisplay.ShowImageIOS(path);
					MyImageDisplay.mid.ShowImageIOS(path);
					if (image.AsPNG().Save(filepath, false))
					{

					}
					imagePicker.DismissViewController(true, (Action)null);
				};
				imagePicker.Canceled += (sender, e) =>
				{
					((UIImagePickerController)sender).DismissViewController(true, null);
				};
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			//return true;
		}


		public void ShowSelectedImage(MyImageDisplay _myimagedisplay)
		{
			try
			{
				var parent = UIApplication.SharedApplication.KeyWindow.RootViewController;
				var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.PhotoLibrary };
				parent.PresentViewController(imagePicker, true, null);
				imagePicker.FinishedPickingMedia += (sender, e) =>
				{
					var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tmp.png");
					var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
					image.AsPNG().Save(filepath, false);
					var path = filepath;

					//_myimagedisplay.ShowImageIOS(path);
					MyImageDisplay.mid.ShowImageIOS(path);
					if (image.AsPNG().Save(filepath, false))
					{

					}
					imagePicker.DismissViewController(true, (Action)null);
				};
				imagePicker.Canceled += (sender, e) =>
				{
					((UIImagePickerController)sender).DismissViewController(true, null);
				};
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			//return true;
		}

	}
}


