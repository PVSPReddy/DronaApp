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
    to initiate local notifications in ios you have to add the following line in appdelegate.cs in FinishedLaunching method.
    #region for local notifications
    var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
    UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
    #endregion
    */
    /*
    error report: There is a bug in the iOS simulator that will fire the delegate notification twice. This issue should not occur when running the application on a device.
    */
    public class ILocalNotificationsServices : ILocalNotifications
    {
        public ILocalNotificationsServices() { }

        public async Task<bool> GetNotificationImmediately()
        {
            bool isNotified = false;
            try
            {
                UILocalNotification notification = new UILocalNotification();
                notification.FireDate = NSDate.FromTimeIntervalSinceNow(15);//in seconds
                //notification.AlertTitle = "Alert Title"; // required for Apple Watch notifications
                notification.AlertAction = "View Alert";
                notification.AlertBody = "Your 15 second alert has fired!";
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
    }
}

