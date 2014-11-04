# AdBuddizXamarin
---
AdBuddiz plugin for Xamarin.iOS and Xamarin.Android.

Update `AdBuddiz.Xamarin/Lib/libAdBuddiz.a` with the newest AdBuddiz .a library for iOS.

Update `AdBuddiz.Xamarin/Jars/AdBuddiz.jar` with the newest AdBuddiz jar for Android.


# MANUAL


# 1. Add reference to your app.

Add reference to `Xamarin.iOs.dll` in your iOS project.

Add reference to `Xamarin.Android.dll` in your Android project.

# 2. Configure SDK

## a) Configure SDK

### iOS

In your `AppDelegate`, add `using` statement, override `OnActivated` and add following code:

	using AdBuddiz.Xamarin;

	public override void OnActivated(UIApplication application) 
	{
		// don't call base!
		...
		AdBuddizHandler.Instance.SetPublisherKey("TEST_PUBLISHER_KEY");
 		AdBuddizHandler.Instance.CacheAds();
		...
	}

### Android

#### i. Add permissions
Add the following permissions:

	<!-- Mandatory permission -->
   	<uses-permission android:name="android.permission.INTERNET" />

	<!-- Optional, but without them, you might get less ads and tracking could be less accurate -->
   	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
   	<uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />

#### ii. Add AdBuddiz Activity
In the `<application ...>` part, add the following Activity with its **mandatory** theme:

	<application ...>
     ...
     <activity android:name="com.purplebrain.adbuddiz.sdk.AdBuddizActivity" 
               android:theme="@android:style/Theme.Translucent" />
   	</application>

#### iii. Configure and initialize SDK.
You should request to cache ads as soon as your app starts. In the first created Activity of your app, add the following lines:

	using AdBuddiz.Xamarin;

	protected override void OnCreate(Bundle bundle) 
	{
		base.OnCreate(bundle);
		...
		AdBuddizHandler.Instance.SetPublisherKey("TEST_PUBLISHER_KEY");
		AdBuddizHandler.Instance.CacheAds(this);
		...		
	}

## b) Optional - Test Mode
You can activate test mode by calling the following code **before** `CasheAds` call:
	
	AdBuddizHandler.Instance.SetTestModeActive();

## c) Optional - Logs
You can control the AdBuddiz SDK log level by calling the following code before `CacheAds` call:

	AdBuddizHandler.Instance.SetLogLevel(ABLogLevel.ABLogLevelInfo); // or ABLogLevelError, ABLogLevelSilent

# 3. Show Ad

## a) Show ad

Wherever you want to display an ad, add the following import and SDK call:
	
	AdBuddizHandler.Instance.ShowAd();

## b) Optional - Events
In order to get more information about the SDK behavior, you can register event handlers. Event handlers can be added or removed at any time.
	
	AdBuddizHandler.Instance.DidCacheAd += delegate { Console.WriteLine("DidCacheAd!"); };
 	AdBuddizHandler.Instance.DidShowAd += delegate { Console.WriteLine("DidShowAd!"); };
 	AdBuddizHandler.Instance.DidClickAd += delegate{ Console.WriteLine("DidClickAd!"); };
 	AdBuddizHandler.Instance.DidHideAd += delegate { Console.WriteLine("DidHideAd!"); };

 	AdBuddizHandler.Instance.DidFailToShowAd += (s,e) => 
	{ 
    	Console.WriteLine("DidFailToShowAd!");
    	Console.WriteLine("error="+e.ErrorDescription);
 	};

## c) Optional - Request SDK Status

To know if the SDK will be able to display an ad, you can call `IsReadyToShowAd`.

	if (AdBuddizHandler.Instance.IsReadyToShowAd) 
	{
      ...
   	}
