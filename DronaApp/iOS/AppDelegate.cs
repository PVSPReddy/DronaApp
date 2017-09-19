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
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            #endregion

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

