using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace DronaApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();


            #region for screen width and height
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            BaseContentPage.screenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            BaseContentPage.screenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            #endregion

            #region for local notifications

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

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }
            else
            {

            }
            #endregion

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

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
    }
}

