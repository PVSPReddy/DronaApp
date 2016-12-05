using System;
using DronaApp;
using DronaApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyButtonOne), typeof(MyButtonOneRenderer))]
namespace DronaApp.iOS
{
	public class MyButtonOneRenderer : ButtonRenderer
	{
		public MyButtonOneRenderer(){}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.BackgroundColor = UIColor.Blue;
				Control.TouchUpInside += (object sender, EventArgs er) =>
				{
					var _cords1 = Control.Bounds;
					var _cords2 = Control.Frame;
					var _cordsx1 = Control.CenterXAnchor;
					var _cordsy1 = Control.CenterXAnchor;
					var _cordsStartPoint = Control.AccessibilityActivationPoint;
				};
				Control.TouchDown += (object sender, EventArgs er) =>
				{
					NSSet touches = new NSSet();
					UITouch touch = new UITouch();
					if (touch != null)
					{
						var xNew = touch.GetPreciseLocation(this).X;
						var yNew = touch.GetPreciseLocation(this).Y;
						var xOld = touch.GetPrecisePreviousLocation(this).X;
						var yOld = touch.GetPrecisePreviousLocation(this).Y;
						touch = null;
					}

					var _cords1 = Control.Bounds;
					var _cords2 = Control.Frame;
					var _cordsx1 = Control.CenterXAnchor;
					var _cordsy1 = Control.CenterXAnchor;
					var _cordsStartPoint = Control.AccessibilityActivationPoint;
					var point = ((UIButton)sender).Frame;
					var points = ((UIButton)sender).AccessibilityFrame;

				};
				////UIGestureRecognizer tapping = new UIGestureRecognizer();

				//Control.gestur
				//Control.BackgroundRectForBounds(new CoreGraphics.CGRect(0, 0, 100, 50));

				var cords1 = Control.Bounds;
				var cords2 = Control.Frame;
				var cordsx1 = Control.CenterXAnchor;
				var cordsy1 = Control.CenterXAnchor;
				var cordsStartPoint = Control.AccessibilityActivationPoint;
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

		public override void TouchesBegan(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			if (touch != null)
			{
				var xNew = touch.GetPreciseLocation(this).X;
				var yNew = touch.GetPreciseLocation(this).Y;
				var xOld = touch.GetPrecisePreviousLocation(this).X;
				var yOld = touch.GetPrecisePreviousLocation(this).Y;
			}
		}

		public override void TouchesMoved(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesMoved(touches, evt);
		}

		public override void TouchesEstimatedPropertiesUpdated(Foundation.NSSet touches)
		{
			base.TouchesEstimatedPropertiesUpdated(touches);
		}

		public override void TouchesCancelled(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIKit.UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
		}
	}
}

