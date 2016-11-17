using System;

using Xamarin.Forms;

namespace DronaApp
{

	/* ios
	In Info.plist
	-------------
	add this
	--------
	<key>NSLocationAlwaysUsageDescription</key>
    <string>Can we use your location</string>
	<key>NSLocationWhenInUseUsageDescription</key>
    <string>We are using your location</string>

	in App.Deligate method
	----------------------
	add this
	--------
	Xamarin.FormsMaps.Init();

	Android
	in MainActivity
	---------------
	add this
	--------
	Xamarin.FormsMaps.Init(this, bundle);

	in AndroidManifest
	------------------
	add this
	--------
	<meta-data android:name="com.google.android.maps.v2.API_KEY"
            android:value="AbCdEfGhIjKlMnOpQrStUvWValueGoesHere" />

	give permissions for
	--------------------
	AccessCoarseLocation
	AccessFineLocation
	AccessLocationExtraCommands
	AccessMockLocation
	AccessNetworkState
	AccessWifiState
	Internet
	*/
	public class MapTabbedPage : TabbedPage
	{
		public MapTabbedPage()
		{
			Children.Add(new MapOnePCL() {Title="MainMap", Icon=null });
			Children.Add(new StaticMapPagePCL() { Title = "my Loc Map", Icon = null });
			Children.Add(new MapOnePCL() { Title = "Map_Pins", Icon = null });
			Children.Add(new CustomMapPage() { Title = "Custom", Icon = null });
		}

	}
}

