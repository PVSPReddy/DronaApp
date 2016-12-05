using System;
using DronaApp;
using DronaApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(MyViewCellOne), typeof(MyViewCellOneRender))]
namespace DronaApp.iOS
{
	public class MyViewCellOneRender : ViewCellRenderer
	{
		public MyViewCellOneRender() { }

		public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
		{
			MessagingCenter.Subscribe<ListViewTouchCoordinates>(this, "hi", (obj) =>
			{
				GetData(tv);
			});
			return base.GetCell(item, reusableCell, tv);

		}

		void GetData(UITableView tv)
		{
			try
			{
				var tv1 = tv.Subviews;
				var tv2 = tv1[0].Subviews;

				var tv3 = tv2[ListViewTouchCoordinates.counts];
				if (tv3 != null)
				{
					var subview = tv2[tv2.Length - 1];
					var frame1 = tv2[tv2.Length - 1].Frame;
					var bounds1 = tv2[tv2.Length - 1].Bounds;
					var center1 = tv2[tv2.Length - 1].Center;
					var x1 = frame1.X;
					var y1 = frame1.Y;
					var width1 = frame1.Width;
					var height1 = frame1.Height;
					var width2 = bounds1.Width;


					var finalFrame = frame1.Right;
					var finalframey = frame1.Bottom;



					var point = subview.AccessibilityActivationPoint;

					//Names.cordns = new Rectangle(x1,y1,width,height);
				}
				if (tv2.Length > 0)
				{
					var subview = tv2[tv2.Length - 1];
					var frame1 = tv2[tv2.Length - 1].Frame;
					var bounds1 = tv2[tv2.Length - 1].Bounds;
					var center1 = tv2[tv2.Length - 1].Center;
					var x1 = frame1.X;
					var y1 = frame1.Y;
					var width1 = frame1.Width;
					var height1 = frame1.Height;
					var width2 = bounds1.Width;


					var finalFrame = frame1.Right;
					var finalframey = frame1.Bottom;



					var point = subview.AccessibilityActivationPoint;

					//Names.cordns = new Rectangle(x1,y1,width,height);
				}

			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}

