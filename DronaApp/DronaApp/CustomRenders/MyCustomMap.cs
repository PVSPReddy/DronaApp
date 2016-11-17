using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DronaApp
{
	public class MyCustomMap : Map
	{
		public MyCustomMap(){}

		public List<CustomPins> customPin { get; set; }
	}

	public class CustomPins
	{
		public string pinId { get; set; }
		public Pin pin { get; set; }
		public string urls { get; set; }
	}
}

