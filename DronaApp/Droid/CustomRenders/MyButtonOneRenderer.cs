using System;
using Android.Views;
using DronaApp;
using DronaApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly : ExportRenderer(typeof(MyButtonOne), typeof(MyButtonOneRenderer))]
namespace DronaApp.Droid
{
	public class MyButtonOneRenderer : ButtonRenderer, Android.Views.View.IOnTouchListener
	{
		public MyButtonOneRenderer(){}
		public float _scaleFactor = 1.0f;

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.SetBackgroundColor(Android.Graphics.Color.Blue);
				Control.SetOnTouchListener(this);
				//Control.Touch += (object sender, TouchEventArgs er) =>
				//{
				//	var cordx1 = Control.GetX();
				//	var cordy1 = Control.GetY();


				//	//MotionEvent me = MotionEvent.ActionToString(MotionEventActions.Up);
				//	//MotionEventActions mev = new MotionEventActions.Down;
				//};
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

		public bool OnTouch(Android.Views.View v, MotionEvent e)
		{
			switch (e.Action)
			{
				case MotionEventActions.Down:
					var cordx1 = e.GetX();
					var cordy1 = e.GetY();
					var cordx2 = v.GetX();
					var cordy2 = v.GetY();
					x1 = cordx1;
					break;
					//case MotionEventActions.Move:
					//	var left = (int)(e.RawX - x1);
					//	var right = (left + v.Width);
					//	v.Layout(left, v.Top, right, v.Bottom);
					//	break;
			}

			/*ScaleGestureDetector gestureDetect = new ScaleGestureDetector(Forms.Context, new MyScaleListener(this));
			gestureDetect.OnTouchEvent(e);
			MotionEventActions actions = e.Action & MotionEventActions.Mask;
			int pointerindex;


			switch (actions)
			{
				case MotionEventActions.Down:
					var cordx1 = e.GetX();
					var cordy1 = e.GetY();
					x1 = cordx1;
					y1 = cordy1;
					activePointerid = e.GetPointerId(0);
					break;

				case MotionEventActions.Move:
					pointerindex = e.FindPointerIndex(activePointerid);
					var cordx2 = e.GetX(pointerindex);
					var cordy2 = e.GetY(pointerindex);
					if (!gestureDetect.IsInProgress)
					{
						var deltax = cordx2 - x1;
						var deltay = cordy2 - y1;
						x2 = deltax;
						y2 = deltay;
						Invalidate();
					}
					break;
				case MotionEventActions.Up:
					break;
				case MotionEventActions.Cancel:
					// This events occur when something cancels the gesture (for example the
					// activity going in the background) or when the pointer has been lifted up.
					// We no longer need to keep track of the active pointer.

					activePointerid = InvalidPointerid;
					break;
				case MotionEventActions.PointerUp:
					// We only want to update the last touch position if the the appropriate pointer
					// has been lifted off the screen.
					pointerindex = (int)(e.Action & MotionEventActions.PointerIndexMask) >> (int)MotionEventActions.PointerIndexShift;
					int pointerid = e.GetPointerId(pointerindex);
					if (pointerid == activePointerid)
					{
						// This was our active pointer going up. Choose a new
						// action pointer and adjust accordingly
						int newpointerindex = pointerindex == 0 ? 1 : 0;
						cordx1 = e.GetX(newpointerindex);
						cordy1 = e.GetY(newpointerindex);
						activePointerid = e.GetPointerId(newpointerindex);
					}
					break;
			}*/

			return true;
			//throw new NotImplementedException();
		}


		int InvalidPointerid = -1, activePointerid;
		float x1, x2;
		float y1, y2;
		public override bool OnTouchEvent(Android.Views.MotionEvent e)
		{
			ScaleGestureDetector gestureDetect = new ScaleGestureDetector(Forms.Context, new MyScaleListener(this));
			gestureDetect.OnTouchEvent(e);
			MotionEventActions actions = e.Action & MotionEventActions.Mask;
			int pointerindex;


			switch (actions)
			{
				case MotionEventActions.Down:
					var cordx1 = e.GetX();
					var cordy1 = e.GetY();
					x1 = cordx1;
					y1 = cordy1;
					activePointerid = e.GetPointerId(0);
					break;

				case MotionEventActions.Move:
					pointerindex = e.FindPointerIndex(activePointerid);
					var cordx2 = e.GetX(pointerindex);
					var cordy2 = e.GetY(pointerindex);
					if (!gestureDetect.IsInProgress)
					{
						var deltax = cordx2 - x1;
						var deltay = cordy2 - y1;
						x2 = deltax;
						y2 = deltay;
						Invalidate();
					}
					break;
				case MotionEventActions.Up:
					break;
				case MotionEventActions.Cancel:
					// This events occur when something cancels the gesture (for example the
					// activity going in the background) or when the pointer has been lifted up.
					// We no longer need to keep track of the active pointer.

					activePointerid = InvalidPointerid;
					break;
				case MotionEventActions.PointerUp:
					// We only want to update the last touch position if the the appropriate pointer
					// has been lifted off the screen.
					pointerindex = (int)(e.Action & MotionEventActions.PointerIndexMask) >> (int)MotionEventActions.PointerIndexShift;
					int pointerid = e.GetPointerId(pointerindex);
					if (pointerid == activePointerid)
					{
						// This was our active pointer going up. Choose a new
						// action pointer and adjust accordingly
						int newpointerindex = pointerindex == 0 ? 1 : 0;
						cordx1 = e.GetX(newpointerindex);
						cordy1 = e.GetY(newpointerindex);
						activePointerid = e.GetPointerId(newpointerindex);
					}
					break;
			}

			return true;
			//return base.OnTouchEvent(e);
		}
	}

	public class MyScaleListener : ScaleGestureDetector.SimpleOnScaleGestureListener
	{
		private readonly MyButtonOneRenderer _view;
		//private float _scaleFactor = 1.0f;

		public MyScaleListener(MyButtonOneRenderer view)
		{
			_view = view;
		}

		public override bool OnScale(ScaleGestureDetector detector)
		{

			_view._scaleFactor *= detector.ScaleFactor;

			// put a limit on how small or big the image can get.
			if (_view._scaleFactor > 5.0f)
			{
				_view._scaleFactor = 5.0f;
			}
			if (_view._scaleFactor < 0.1f)
			{
				_view._scaleFactor = 0.1f;
			}

			_view.Invalidate();
			return true;
		}
	}
}