using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DronaApp
{
	public partial class CustomMapPage : ContentPage
	{
		public CustomMapPage()
		{
			InitializeComponent();
			CustomProperties cp = new CustomProperties();
			var screenWidth = cp.AppScreenWidth;
			var screenHeight = cp.AppScreenHeight;

			var pin1 = new CustomPins()
			{
				pin = new Pin()
				{
					Type = PinType.Place,
					Position = new Position(16.904248, 82.001445),
					Label = "My Home",
					Address = "Rayavaram," +
					"East Godavari Dist.," +
					"AndhraPradesh," +
					"India."
				},
				pinId = "SivaPrasad",
				urls = "https://www.facebook.com/index.php"
			};

			cmap = new MyCustomMap()
			{
				MapType = MapType.Hybrid,
				HeightRequest = (screenHeight * 7) / 10,
				WidthRequest = (screenWidth * 9) / 10,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			cmap.customPin = new List<CustomPins>() { pin1 };
			cmap.Pins.Add(pin1.pin);
			cmap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(16.904248, 82.001445), Distance.FromMiles(0.3)));


			StackLayout holder = new StackLayout()
			{
				Children = { cmap },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			Content = holder;
		}
		MyCustomMap cmap;
	}
}
