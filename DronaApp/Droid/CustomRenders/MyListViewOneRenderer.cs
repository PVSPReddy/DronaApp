using System;
using DronaApp;
using DronaApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyListViewOne), typeof(MyListViewOneRenderer))]
namespace DronaApp.Droid
{
	public class MyListViewOneRenderer : ListViewRenderer
	{
		public MyListViewOneRenderer(){}

		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Scroll += (object sender, Android.Widget.AbsListView.ScrollEventArgs er) =>
				{
					ListViewTouchCoordinates.dbn.StartFloating(0, 0, 0, false);
				};

				Control.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs er) =>
				{
					var item = er.Id;
					var height = er.View.Height;
					var cordsx1 = er.View.GetX();
					var cordsy1 = er.View.GetY();
					var scale = Resources.DisplayMetrics.Density;
					//var cordsx2 = (int)(((cordsx1) - 0.5f) / 3);
					//var cordsy2 = (int)(((cordsy1 + height) - 0.5f) / 3);
					var cordsx2 = (int)(((cordsx1) - 0.5f) / scale);
					var cordsy2 = (int)(((cordsy1 + height) - 0.5f) / scale);

					ListViewTouchCoordinates.dbn.StartFloating(cordsx2, cordsy2, item, true);
				};

				if (e.NewElement != null)
				{
					//Control.Adapter = new NativeAndroidListViewAdapter(Forms.Context as Android.App.Activity, e.NewElement as MyListViewOne);
				}
			}

			if (e.OldElement != null)
			{

			}

			if (e.NewElement != null)
			{

			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}


	}
}

