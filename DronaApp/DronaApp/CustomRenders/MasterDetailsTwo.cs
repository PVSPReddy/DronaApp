using System;
using Xamarin.Forms;

namespace DronaApp
{
	/*here we can give the width for master page 
	in Android
	----------
	in Main Activity
	----------------
	replce this(1) with the next one(2)
	1)public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            #region For Screen Height & Width
            var pixels = Resources.DisplayMetrics.WidthPixels;
            var scale = Resources.DisplayMetrics.Density;

            var dps = (double)((pixels - 0.5f) / scale);

            App.ScreenWidth = (int)dps;

            pixels = Resources.DisplayMetrics.HeightPixels;
            dps = (double)((pixels - 0.5f) / scale);

            App.ScreenHeight = (int)dps;
            #endregion

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
	2)public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            try
            {
                //TabLayoutResource = Resource.Layout.Tabbar;
                //ToolbarResource = Resource.Layout.Toolbar;

                base.OnCreate(bundle);
                
                #region For Screen Height & Width
            	var pixels = Resources.DisplayMetrics.WidthPixels;
            	var scale = Resources.DisplayMetrics.Density;

            	var dps = (double)((pixels - 0.5f) / scale);

            	App.ScreenWidth = (int)dps;

            	pixels = Resources.DisplayMetrics.HeightPixels;
            	dps = (double)((pixels - 0.5f) / scale);

            	App.ScreenHeight = (int)dps;
            	#endregion

                global::Xamarin.Forms.Forms.Init(this, bundle);

                LoadApplication(new App());
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
	
	in IOS
	------




	*/
	public class MasterDetailsTwo : MasterDetailPage
	{
		public MasterDetailsTwo(){}

		//here we are declaring master width in native statically

	}
}

