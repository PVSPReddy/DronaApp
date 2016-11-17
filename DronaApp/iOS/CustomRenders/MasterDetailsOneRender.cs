using System;
using DronaApp;
using DronaApp.iOS;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly : ExportRenderer(typeof(MasterDetailsOne), typeof(MasterDetailsOneRender))]
namespace DronaApp.iOS
{
	public class MasterDetailsOneRender : PhoneMasterDetailRenderer
	{
		public MasterDetailsOneRender(){}

		[Export("viewDidLayoutSubviews")]
		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			MasterDetailsOne page = (MasterDetailsOne)this.Element;

			var masterViewController = this.ChildViewControllers[0];
			var detailViewController = this.ChildViewControllers[1];

			if (detailViewController.View.Frame.X > 0.0)
			{
				var MasterViewWidth = 100.0f;
				// Adjust the width of the master view
				//RectangleF masterViewFrame = masterViewController.View.Frame;
				var masterViewFrame = masterViewController.View.Frame;
				var deltaX = masterViewFrame.Width - MasterViewWidth;
				masterViewFrame.Width = MasterViewWidth;
				masterViewController.View.Frame = masterViewFrame;

				// Adjust the width of the detail view
				//RectangleF detailViewFrame = detailViewController.View.Frame;
				var detailViewFrame = detailViewController.View.Frame;
				detailViewFrame.X = detailViewFrame.X - deltaX;
				detailViewFrame.Width = detailViewFrame.Width + deltaX;
				detailViewController.View.Frame = detailViewFrame;

				//masterViewController.View.SetNeedsLayout();
				//detailViewController.View.SetNeedsLayout();
			}
		}
	}
}

