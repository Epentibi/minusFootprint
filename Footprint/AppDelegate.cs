using System;
using Foundation;
using UIKit;
using UserNotifications;

namespace Footprint
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public bool shouldUpdateView;

        public AchievementManager.AchievementConfig toUnlock;

        float updateNumber;

        int tasks;

        public int mainSeed;

        // class-level declarations 
        public override UIWindow Window 
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            System.Diagnostics.Debug.WriteLine(Environment.MachineName);

            var name = System.Environment.MachineName.ToLower();
            if (name.Contains("minnie") || name.Contains("linjing"))
            {
                System.Diagnostics.Debug.WriteLine("special phone detected");
            }

            if (TimeZoneInfo.Local.StandardName == "CST")
            {
                System.Diagnostics.Debug.WriteLine("TimeZone is China");
            }

            //System.Diagnostics.Debug.WriteLine("timezone is " + TimeZoneInfo.Local.StandardName);

            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                                                                        (granted, error) =>
                                                                        {
                                                                            if (granted)
                                                                                InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
                                                                        });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var pushSettings = UIUserNotificationSettings.GetSettingsForTypes(
                        UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                        new NSSet());

                UIApplication.SharedApplication.RegisterUserNotificationSettings(pushSettings);
                UIApplication.SharedApplication.RegisterForRemoteNotifications();
            }
            else
            {
                UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
                UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(notificationTypes);
            }
            mainSeed = new System.Random().Next(int.MinValue, int.MaxValue);
            return true;
        }


        public override void RegisteredForRemoteNotifications(
        UIApplication application, NSData deviceToken)
        {
            // Get current device token

            var tokenBytes = deviceToken.Bytes;

            byte[] token = deviceToken.ToArray();

            var DeviceToken = BitConverter.ToString(token).Replace("-", "");

            System.Diagnostics.Debug.WriteLine(DeviceToken);

            // Get previous device token
            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

            // Has the token changed?
            if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
            {
                if (TimeZoneInfo.Local.StandardName == "CST")
                {
                    System.Diagnostics.Debug.WriteLine("TimeZone is China, adding or replacing token");

                    SQLConnector.executeAsyncQuery("use minusFootprint; insert into chinaNotification values(" + "'" + DeviceToken + "'" + "); ");
                }
                //TODO: Put your own logic here to notify your server that the device token has changed/been created!
            }

            // Save new device token
            NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
            System.Diagnostics.Debug.WriteLine(DeviceToken);
        }

        public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
        {
            System.Diagnostics.Debug.WriteLine("Failed to register push notification");
            //new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
        }


        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo)
        {
            ProcessNotification(userInfo, false);
        }

        void ProcessNotification(NSDictionary options, bool fromFinishedLaunching)
        {
            // Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
            if (null != options && options.ContainsKey(new NSString("aps")))
            {
                //Get the aps dictionary
                NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;

                string alert = string.Empty;

                //Extract the alert text
                // NOTE: If you're using the simple alert by just specifying
                // "  aps:{alert:"alert msg here"}  ", this will work fine.
                // But if you're using a complex alert with Localization keys, etc.,
                // your "alert" object from the aps dictionary will be another NSDictionary.
                // Basically the JSON gets dumped right into a NSDictionary,
                // so keep that in mind.
                if (aps.ContainsKey(new NSString("alert")))
                    alert = (aps[new NSString("alert")] as NSString).ToString();

                //If this came from the ReceivedRemoteNotification while the app was running,
                // we of course need to manually process things like the sound, badge, and alert.
                if (!fromFinishedLaunching)
                {
                    //Manually show an alert
                    if (!string.IsNullOrEmpty(alert))
                    {
                        UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
                        avAlert.Show();
                    }
                }
            }
        }
    }
}

