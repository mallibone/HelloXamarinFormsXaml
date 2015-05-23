using System;
using System.Collections.Generic;
using System.Linq;
using AudioToolbox;
using Foundation;
using UIKit;

namespace HelloXamarinForms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            if (options != null && options.ContainsKey(UIApplication.LaunchOptionsRemoteNotificationKey))
            {
                var notificationData = options[UIApplication.LaunchOptionsRemoteNotificationKey] as NSDictionary;
                var parameeterOne = notificationData["parameterOne"].ToString();
                var parameterTwo = Convert.ToInt32(notificationData["parameterOne"].ToString());

            // Send message i.e. process push notification
                // process notification data
            }

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            const string notificationHubConnectionString = "Endpoint=sb://mallibone.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=7PQVHyT7QHn4d+aqU+MU3l1uouArapJgZXKoFdiio3c=";
            const string notificationHubName = "mallibone";

            Hub = new SBNotificationHub(notificationHubConnectionString, notificationHubName);

            Hub.UnregisterAllAsync(deviceToken, (error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error calling Unregister: {0}", error.ToString());
                    return;
                }

                var deviceId = Convert.ToBase64String(deviceToken.ToArray());
                var tag = Guid.NewGuid().ToString();
                var tags = new List<string> { tag };

                Hub.RegisterNativeAsync(deviceToken, new NSSet(tags.ToArray()), (errorCallback) =>
                {
                    if (errorCallback != null)
                    {
                        Console.WriteLine("RegisterNativeAsync error: " + errorCallback.ToString());
                        return;
                    }
                });
            });
        }

        public override void ReceivedRemoteNotification(UIApplication application, NSDictionary notificationData)
        {
            if (application.ApplicationState == UIApplicationState.Inactive
                || application.ApplicationState == UIApplicationState.Background)
            {
                // Handle notification on wake
                return;
            }


            var parameeterOne = notificationData["parameterOne"].ToString();
            var parameterTwo = Convert.ToInt32(notificationData["parameterOne"].ToString());

            // Send message i.e. process push notification


            SystemSound.Vibrate.PlaySystemSound();
        }

            //if (!IsValidQ1PushMessage(notificationData)) return;

            //if (application.ApplicationState == UIApplicationState.Inactive
            //    || application.ApplicationState == UIApplicationState.Background)
            //{
            //    ProcessNotificationOnLaunch(notificationData);
            //    Messenger.Default.Send(new LaunchedOnPushNotifiationMessage());
            //    return;
            //}

            //if (notificationData[ClientConstants.PushKeyIdentifier].ToString() == ClientConstants.ClaimUpdateIdentifier)
            //{
            //    var rawClaimId = notificationData[ClientConstants.PushValueIdentifier].ToString();
            //    var claimId = Convert.ToInt32(rawClaimId);
            //    Messenger.Default.Send(new ClaimChangePushNotifiationMessage(claimId));
            //}

    }
}
