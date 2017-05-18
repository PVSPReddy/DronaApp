using System;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using CoreGraphics;
using DronaApp.iOS;

[assembly: Dependency(typeof(ScreenshotService))]
namespace DronaApp.iOS
{
    public class ScreenshotService : IScreenshot
    {
        public ScreenshotService(){}

        public void Capture(double header, double fotter)
        {
            try
            {
                byte[] senddata = new byte[0];
                var view = UIApplication.SharedApplication.KeyWindow.RootViewController.View;

                UIGraphics.BeginImageContext(view.Frame.Size);
                int screenWidth = (int)UIScreen.MainScreen.Bounds.Width;
                int screenHeight = (int)UIScreen.MainScreen.Bounds.Height;
                CGRect dsds = new CGRect(0, -(header / 0.5833), screenWidth, screenHeight + (fotter / 0.2916));
                view.DrawViewHierarchy(dsds, true);
                var image = UIGraphics.GetImageFromCurrentImageContext();
                UIGraphics.EndImageContext();

                using (var imageData = image.AsPNG())
                {
                    var bytes = new byte[imageData.Length];

                    System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, bytes, 0, Convert.ToInt32(imageData.Length));
                    senddata = bytes;
                    App.Current.MainPage.Navigation.PushModalAsync(new ScreenShotResult(senddata));
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}

