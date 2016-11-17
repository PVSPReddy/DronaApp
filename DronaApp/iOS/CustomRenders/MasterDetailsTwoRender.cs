using System;
using System.Reflection;
using CoreGraphics;
using DronaApp;
using DronaApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MasterDetailsTwo), typeof(MasterDetailsTwoRender))]
namespace DronaApp.iOS
{
	public class MasterDetailsTwoRender : PhoneMasterDetailRenderer
	{
		public MasterDetailsTwoRender(){}
		//PropertyInfo detailBoundsProperty;
		//public override void ViewDidLayoutSubviews()
		//{
		//    base.ViewDidLayoutSubviews();
		//    MyMasterWidth page = (MyMasterWidth)this.Element;
		//    var mastercontrol = this.ChildViewControllers[0];
		//    RectangleF masterViewFrame = (RectangleF)mastercontrol.View.Frame;
		//    masterViewFrame.Width = page.DrawerWidth;
		//    mastercontrol.View.Frame = masterViewFrame;
		//    if (detailBoundsProperty == null)
		//        detailBoundsProperty = this.Element.GetType().GetProperty("DetailBounds", BindingFlags.NonPublic | BindingFlags.Instance);
		//    if (detailBoundsProperty != null && detailBoundsProperty.CanWrite)
		//        detailBoundsProperty.SetValue(this.Element, masterViewFrame);
		//    mastercontrol.View.SetNeedsLayout();
		//}

		private readonly nfloat SplitterWidth = (nfloat)0.5;

		protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
				((MasterDetailPage)e.OldElement).IsPresentedChanged -= onIsPresentedChanged;
			if (e.NewElement != null)
				((MasterDetailPage)e.NewElement).IsPresentedChanged += onIsPresentedChanged;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (Element != null)
				((MasterDetailPage)Element).IsPresentedChanged -= onIsPresentedChanged;
		}

		// Workaround to preserve delimiter color. It is set to white (hardcoded) by Xamarins ViewDidLoad method.
		public override void ViewDidLoad()
		{
			var color = this.View.BackgroundColor;
			base.ViewDidLoad();
			this.View.BackgroundColor = color;
		}

		private void onIsPresentedChanged(object sender, EventArgs e)
		{
			adjustDetailWidth();
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			adjustDetailWidth();
		}

		private void adjustDetailWidth()
		{
			var mainWidth = View.Frame.Width;
			var masterWidth = ChildViewControllers[0].View.Frame.Width;
			var detailFrame = ChildViewControllers[1].View.Frame;
			var masterVisible = ((MasterDetailPage)Element).IsPresented;

			nfloat desiredX = 0;
			nfloat desiredWidth = mainWidth;
			if (masterVisible)
			{
				desiredX = masterWidth + SplitterWidth;
				desiredWidth = mainWidth - desiredX;
			}

			if (desiredX != detailFrame.X || desiredWidth != detailFrame.Width)
			{
				SetDetailBounds(new Xamarin.Forms.Rectangle(desiredX, detailFrame.Y, desiredWidth, detailFrame.Height));
			}
		}

		PropertyInfo detailBoundsProperty;

		private void SetDetailBounds(Xamarin.Forms.Rectangle rectangle)
		{
			// unfortunately, this doesnt animate the width, but I can live with that
			// (width is set at once, X is animated)
			UIView.Animate(
				0.2,
				() => ChildViewControllers[1].View.Frame = new CGRect(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
			);

			// must set internal DetailBounds because base.ViewDidLayoutSubviews always sets X to 0
			if (detailBoundsProperty == null)
				detailBoundsProperty = this.Element.GetType().GetProperty("DetailBounds", BindingFlags.NonPublic | BindingFlags.Instance);
			if (detailBoundsProperty != null && detailBoundsProperty.CanWrite)
				detailBoundsProperty.SetValue(this.Element, rectangle);
		}
	}
}