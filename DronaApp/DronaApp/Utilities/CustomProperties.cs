using System;

using Xamarin.Forms;

namespace DronaApp
{
	public class CustomProperties : ContentPage
	{
       private double appScreenHeight;
		private double appScreenWidth;
		private double appHeadderHeight;
		private double appHeaderWidth;


		public dynamic AppScreenHeight
		{
			get { return appScreenHeight; }
			set { appScreenHeight = value; }
		}

		public dynamic AppScreenWidth
		{
			get { return appScreenWidth; }
			set { appScreenWidth = value; }
		}
		public dynamic AppHeadderHeight
		{
			get { return appHeadderHeight; }
			set { appHeadderHeight = value; }
		}
		public dynamic AppHeaderWidth
		{
			get { return appHeaderWidth; }
			set { appHeaderWidth = value; }
		}

		/*#region
		 #endregion*/


		public CustomProperties()
		{
			appScreenHeight = App.ScreenHeight + 3;
			appScreenWidth = App.ScreenWidth + 3;
			appHeadderHeight = (appScreenHeight * 10) / 100;
			appHeaderWidth = appScreenWidth;
		}
	}
}


