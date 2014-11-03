using System;

namespace AdBuddiz.Xamarin
{
    public enum AdBuddizError
    {
        UnsupportedIosSdk = 0,
        ConfigNotReady = 1,
        ConfigExpired = 2,
        MissingPublisherKey = 3,
        InvalidPublisherKey = 4,
        PlacementBlocked = 5,
        NoNetworkAvailable = 6,
        NoMoreAvailableCachedAds = 7,
        NoMoreAvailableAds = 8,
        ShowAdCallsTooClose = 9,
		UnsupportedAndroidSdk = 100,
		ActivityParameterIsNull = 101,
		MissingAdbuddizActivityInManifest = 102,
		MissingInternetPermissionInManifest = 103,
        UnknownExceptionRaised = 999
    }
}

