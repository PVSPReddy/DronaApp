using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DronaApp
{
	public partial class StaticMapPagePCL : ContentPage
	{
		public StaticMapPagePCL()
		{
			InitializeComponent();
			map = new Map()
			{
				HeightRequest = 100,
				WidthRequest = 300,
				VerticalOptions = LayoutOptions.FillAndExpand
			};//initializing map

			map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));//this takes to zeroth on earth and from the farthest possible position above ground

			Position staticAddress = new Position(16.904248, 82.001445); //to give some coordinates(latitudes and longitudes) statically
																		 //the above are coordinates of rayavaram,eastgodavari dist, andhrapradesh, India - 533346

			Distance viewDistanceFromSky = Distance.FromMiles(0.3); //from which distance from sky we are viewing the map

			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(0, 0), viewDistanceFromSky));//zoming the position

			//map.MoveToRegion(MapSpan.FromCenterAndRadius(staticAddress, viewDistanceFromSky));
			//the above statement takes the map to start at the given coordinates from the given distance above ground

			var pin = new Pin
			{
				Type = PinType.Place,
				Position = staticAddress,
				Label = "My Home",
				Address = "Rayavaram," +
					"East Godavari Dist.," +
					"AndhraPradesh," +
					"India."
			};// initializing pin and giving it the corordinates from the position declared in the above lines

			map.Pins.Add(pin);// adding the initialized pin on the map declared

			Button MyPlace = new Button()
			{
				Text = "Go To My Place",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MoveToRegion(MapSpan.FromCenterAndRadius(staticAddress, viewDistanceFromSky));
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			StackLayout holder = new StackLayout()
			{
				Children = { map, MyPlace },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			Content = holder;
		}
		Map map;
	}
}
