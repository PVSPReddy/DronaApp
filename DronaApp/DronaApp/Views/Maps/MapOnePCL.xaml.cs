using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DronaApp
{
	public partial class MapOnePCL : ContentPage
	{
		public MapOnePCL()
		{
			InitializeComponent();
			DependencyService.Get<IGetLocations>().GetPresentLocation();
			Button MyPlace = new Button()
			{
				Text = "Go To My Place",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					DependencyService.Get<IGetLocations>().GetPresentLocation();
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			StackLayout holder = new StackLayout()
			{
				Children = { MyPlace },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			Content = holder;
		}
	}
}
