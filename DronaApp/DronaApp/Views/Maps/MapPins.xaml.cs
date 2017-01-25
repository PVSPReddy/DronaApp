using System;
using System.Collections.Generic;

using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace DronaApp
{
	public partial class MapPins : ContentPage
	{
		public MapPins()
		{
			InitializeComponent();
			CustomProperties cp = new CustomProperties();
			var screenWidth = cp.AppScreenWidth;
			var screenHeight = cp.AppScreenHeight;

			map = new Map()
			{
				HeightRequest = 100,
				WidthRequest = 300,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

			Pinlocation1 = new Pin()
			{
				Type = PinType.Place,
				Position = new Position(16.904248, 82.001445),
				Label = "My Home",
				Address = "Rayavaram," +
					"East Godavari Dist.," +
					"AndhraPradesh," +
					"India."
			};
			Pinlocation2 = new Pin()
			{
				Type = PinType.Place,
				Position = new Position(17.428575, 78.433162),
				Label = "My Work Place",
				Address = "Roadno:2," +
					"Srinagar Colony," +
					"Jubliee Hills," +
					"Telengana" +
					"India."
			};
			Pinlocation3 = new Pin()
			{
				Type = PinType.Place,
				Position = new Position(17.4540934385555, 78.43349330127239),
				Label = "My Living Place",
				Address = "Erragadda," +
					"Hyderabad," +
					"Telengana," +
					"India."
			};
			Pinlocation4 = new Pin()
			{
				Type = PinType.Place,
				Position = new Position(24.738924141821578, 71.76834136247635),
				Label = "My Previous living",
				Address = "Momadevi Town ship," +
					"Sanchore," +
					"Rajasthan," +
					"India."
			};


			//map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));
			//map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.428575, 78.433162), Distance.FromMiles(0.3)));
			//map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.428575, 78.433162), Distance.FromMiles(0.3)));
			//var position = new Position(17.428575, 78.433162); // Latitude, Longitude

			map.Pins.Add(Pinlocation1);
			map.Pins.Add(Pinlocation2);


			Button MyHome = new Button()
			{
				Text = "Rym",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(16.904248, 82.001445), Distance.FromMiles(0.3)));
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			Button MyWork = new Button()
			{
				Text = "S.Nagar",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.428575, 78.433162), Distance.FromMiles(0.3)));
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			Button MyTenant = new Button()
			{
				Text = "E.gadda",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(17.4540934385555, 78.43349330127239), Distance.FromMiles(0.3)));
					map.Pins.Add(Pinlocation3);
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};

			Button MyLast = new Button()
			{
				Text = "Rajasthan",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(24.738924141821578, 71.76834136247635), Distance.FromMiles(0.3)));
					map.Pins.Add(Pinlocation4);
					//the above statement takes the map to start at the given coordinates from the given distance above ground
				})
			};
			Button SateliteModel = new Button()
			{
				Text = "Sat",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MapType = MapType.Satellite;
					//the above statement shows satellite imagery based maps
				})
			};
			Button StreetModel = new Button()
			{
				Text = "Street",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MapType = MapType.Street;
					//the above statement shows street based route maps
				})
			};
			Button HybridModel = new Button()
			{
				Text = "Hyb",
				TextColor = Color.White,
				BackgroundColor = Color.Maroon,
				Command = new Command((obj) =>
				{
					map.MapType = MapType.Hybrid;
					//the above statement shows satellite and route based maps
				})
			};

			StackLayout MyPlaces = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children = { MyHome, MyLast, MyTenant, MyWork, SateliteModel, StreetModel, HybridModel },
			};

			StackLayout holder = new StackLayout()
			{
				Children = { map, MyPlaces },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			Content = holder;

		}
		Map map;
		Pin Pinlocation1, Pinlocation2, Pinlocation3, Pinlocation4;
	}
}
