using System;
using CoreLocation;
using DronaApp.iOS;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

[assembly : Dependency(typeof(IGetLocationsService))]
namespace DronaApp.iOS
{
	public class IGetLocationsService : CLLocationManagerDelegate, IGetLocations
	{
		public IGetLocationsService(){}

		//MKMapView mpv = new MKMapView();
		CLLocationManager locationManager = new CLLocationManager();
		//CLLocation locationing = new CLLocation();
		//var loc1 = locationManager.RequestLocation();

		public void GetPresentLocation()
		{
			locationManager.RequestAlwaysAuthorization(); //to access user's location in the background
			locationManager.RequestWhenInUseAuthorization(); //to access user's location when the app is in use.
			try
			{
				//mpv.ShowsUserLocation = true;
				//var datas = mpv.UserLocation;
				//locationManager.//ShowsUserLocation = true;

				locationManager.UpdatedLocation += (object sender, CLLocationUpdatedEventArgs e) =>
				{
					
				};
				if (CLLocationManager.LocationServicesEnabled)
				{
					locationManager.StartMonitoringSignificantLocationChanges();
				}
				else
				{
					Console.WriteLine("Location services not enabled, please enable this in your Settings");
				}
				locationManager.StartUpdatingLocation();



				var location = locationManager.Location.Coordinate;


				//locationManager.UpdatedLocation += (object sender, CLLocationUpdatedEventArgs e) =>
				//{
				//	var loc = e.NewLocation.Coordinate;
				//};
				//locationManager.StartUpdatingLocation();
				//var locs = locationing.Coordinate;
				//if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
				//{
				//	//locationManager.
				//	locationManager.RequestLocation();
				//	var locs2 = locationManager.Location;
				//	// Code that uses features from Xamarin.iOS 7.0 and later
				//}
				//else 
				//{
				//	// Code to support earlier iOS versions
				//}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		public bool GetLocation()
		{
			try
			{
				locationManager.RequestLocation();
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
			return true;
		}

		public override void LocationsUpdated(CLLocationManager manager, CLLocation[] locations)
		{
			//base.LocationsUpdated(manager, locations);
			try
			{
				
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}
	}
}

