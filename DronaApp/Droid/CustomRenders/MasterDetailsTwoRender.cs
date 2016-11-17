using System;
using DronaApp;
using DronaApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MasterDetailsOne), typeof(MasterDetailsTwoRender))]
namespace DronaApp.Droid
{
	#region
	/*in Main Activity
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
	}*/
	#endregion
	public class MasterDetailsTwoRender : MasterDetailRenderer
	{
		public MasterDetailsTwoRender()
		{
			
		}

		public bool firstDone;
		public override void AddView(Android.Views.View child)
		{
			//base.AddView(child);
			if (firstDone)
			{
				MasterDetailsTwo page = (MasterDetailsTwo)this.Element;
				LayoutParams p = (LayoutParams)child.LayoutParameters;
				p.Width = 200;
				base.AddView(child, p);
			}
			else
			{
				firstDone = true;
				base.AddView(child);
			}
		}
		protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
		{
			base.OnElementChanged(oldElement, newElement);

		}
	}
}
