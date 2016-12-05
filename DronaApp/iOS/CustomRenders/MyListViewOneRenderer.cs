using System;
using DronaApp;
using DronaApp.iOS;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyListViewOne), typeof(MyListViewOneRenderer))]
namespace DronaApp.iOS
{
	public class MyListViewOneRenderer : ListViewRenderer
	{
		public MyListViewOneRenderer(){}

		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			//MessagingCenter.Subscribe<ListViewTouchCoordinates>(this, "hi", (senders) =>
			//{
			//	NSIndexPath nsp = NSIndexPath.FromIndex((System.nuint)ListViewTouchCoordinates.counts);
			//	if (nsp != null)
			//	{
			//		var position = Control.RectForRowAtIndexPath(nsp);

			//	}
			//});
			if (Control != null)
			{
				Control.Source = new MyListViewSourceOne(e.NewElement as MyListViewOne);

				//NSIndexPath nsp = NSIndexPath.FromIndex((System.nuint)ListViewTouchCoordinates.counts);
				//NSIndexPath path = new NSIndexPath();
				////var place = Control.IndexPathForSelectedRow;
				//if (nsp != null)
				//{
				//	var position = Control.RectForRowAtIndexPath(nsp);
				//}
			}

			if (e.OldElement != null)
			{

			}

			if (e.NewElement != null)
			{
				Control.Source = new MyListViewSourceOne(e.NewElement as MyListViewOne);
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			Control.Source = new MyListViewSourceOne(Element as MyListViewOne);
			//if (e.PropertyName == MyListViewOne.ItemsProperty.PropertyName)
			//{
			//	Control.Source = new MyListViewSourceOne(Element as MyListViewOne);
			//}
		}
	}
}

