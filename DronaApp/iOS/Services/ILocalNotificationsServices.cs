using System;
using System.Threading.Tasks;
using DronaApp.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ILocalNotificationsServices))]
namespace DronaApp.iOS
{
    /*
    #region for local notifications
    to initiate local notifications in ios you have to add the following line in appdelegate.cs in FinishedLaunching method.
    var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
    UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

    to clear /updatethe badge numbers
    if (options != null)
    {

        // check for a local notification
        if (options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
        {
            UILocalNotification localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
            if (localNotification != null)
            {
                new UIAlertView(localNotification.AlertAction, localNotification.AlertBody, null, "OK", null).Show();
                // reset our badge
                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            }
        }
    }
    #endregion



    #region for local notifications to find and act when app is in foregroung and background
    public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
    {
        // show an alert
        UIAlertController okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody, UIAlertControllerStyle.Alert);
        okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
        UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        
	    if (UIApplication.SharedApplication.ApplicationState.Equals(UIApplicationState.Active))
	    {
	        //App is in foreground. Act on it.
	    }
	    else
	    {
	        //App.Current.MainPage = new EditAlarm();
	    }
	}
	#endregion
    */
    /*
    error report: There is a bug in the iOS simulator that will fire the delegate notification twice. This issue should not occur when running the application on a device.
    */

    public class ILocalNotificationsServices : ILocalNotifications
    {
        public ILocalNotificationsServices() { }

        #region for local notifications to get immediately and repeat at every second
        public async Task<bool> GetNotificationImmediately()
        {
            bool isNotified = false;
            try
            {
                // create the notification
                UILocalNotification notification = new UILocalNotification();

                // set the fire date (the date time in which it will fire)
                notification.FireDate = NSDate.FromTimeIntervalSinceNow(6);//in seconds

                // configure the alert
                //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications

                notification.AlertAction = "View Alert";
                notification.AlertBody = "Your 15 second alert has fired!";

                // modify the badge
                notification.ApplicationIconBadgeNumber = 1;

                //set repeat interval
                notification.RepeatInterval = NSCalendarUnit.Second;

                // set the sound to be the default sound
                notification.SoundName = UILocalNotification.DefaultSoundName;

                // schedule it
                UIApplication.SharedApplication.ScheduleLocalNotification(notification);
                isNotified = true;
            }
            catch (Exception ex)
            {
                isNotified = false;
                var msg = ex.Message;
            }
            return isNotified;
        }
        #endregion


    }
}

