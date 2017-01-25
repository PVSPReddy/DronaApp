using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DronaApp
{
	public partial class MapOnePCL : ContentPage
	{
		public MapOnePCL()
		{
			InitializeComponent();
			//DependencyService.Get<IGetLocations>().GetPresentLocation();

			Geocoder geocode = new Geocoder();

			Map mymaps = new Map()
			{
				HeightRequest = 100,
				WidthRequest = 300,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			Button MyPlace = new Button()
			{
				Text = "Go To My Place",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					
					mymaps.IsShowingUser = true;
					DependencyService.Get<IGetLocations>().GetPresentLocation();
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			StackLayout holder = new StackLayout()
			{
				Children = { mymaps, MyPlace },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
			Content = holder;
		}
	}
}
