using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Views.Accessibility;
using Android.Views;
using Xamarin.Forms;
using Java.Lang;
using Android.Net;
using System;
using DronaApp.Droid;

[assembly: Dependency(typeof(ScreenshotService))]
namespace DronaApp.Droid
{
    public class ScreenshotService : Activity, IScreenshot
    {
        public ScreenshotService(){}

        public void Capture(double header, double fotter)
        {
            try
            {
                var activity = Forms.Context as Activity;

                Android.Views.View view = activity.Window.DecorView;
                view.DrawingCacheEnabled = true;
                view.BuildDrawingCache();
                Bitmap bitmap = view.DrawingCache;
                Rect rect = new Rect();
                activity.Window.DecorView.GetWindowVisibleDisplayFrame(rect);
                int width = activity.WindowManager.DefaultDisplay.Width;
                int height = activity.WindowManager.DefaultDisplay.Height;
                Bitmap screenShotBitmap = Bitmap.CreateBitmap(bitmap, 0, Convert.ToInt32(header / 0.2008), width, height - Convert.ToInt32(fotter / 0.1222));
                view.DestroyDrawingCache();

                byte[] bitmapData = new byte[0];

                using (var stream = new MemoryStream())
                {
                    screenShotBitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                    bitmapData = stream.ToArray();
                }
                App.Current.MainPage.Navigation.PushModalAsync(new ScreenShotResult(bitmapData));
            }
            catch(Java.Lang.Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}

