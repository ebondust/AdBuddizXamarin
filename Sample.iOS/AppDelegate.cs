﻿using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using AdBuddiz.Xamarin;

namespace Sample.iOs
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            window.RootViewController = new RootViewController();
            window.BackgroundColor = UIColor.White;
            
            // make the window visible
            window.MakeKeyAndVisible();
            
            return true;
        }

        public override void OnActivated(UIApplication application)
        {
            AdBuddizHandler.Instance.SetLogLevel(ABLogLevel.ABLogLevelInfo);
            AdBuddizHandler.Instance.SetPublisherKey("TEST_PUBLISHER_KEY");
            AdBuddizHandler.Instance.SetTestModeActive();
            AdBuddizHandler.Instance.CacheAds();

            AdBuddizHandler.Instance.DidFailToShowAd += (sender, e) => 
            {
                Console.WriteLine(e.ErrorDescription);
            };

            AdBuddizHandler.Instance.DidCacheAd += delegate
            {
                Console.WriteLine("DidCasheAd");
            };

            AdBuddizHandler.Instance.DidClick += delegate
            {
                Console.WriteLine("DidClick");
            };

            AdBuddizHandler.Instance.DidShowAd += delegate
            {
                Console.WriteLine("DidShowAd");
            };

            AdBuddizHandler.Instance.DidHideAd += delegate
            {
                Console.WriteLine("DidHideAd");
            };
        }
    }
}
