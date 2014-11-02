using System;

namespace AdBuddiz.Xamarin
{
    public enum ABLogLevel
    {
        ABLogLevelInfo,
        ABLogLevelError,
        ABLogLevelSilent
    };

    public enum AdBuddizError 
    {
        UnsupportedAndroidSdk,
        ConfigNotReady,
        ConfigExpired,
        MissingPublisherKey,
        InvalidPublisherKey,
        PlacementBlocked,
        NoNetworkAvailable,
        NoMoreAvailableCachedAds,
        NoMoreAvailableAds,
        ShowAdCallsTooClose,
        ActivityParameterIsNull,
        MissingAdbuddizActivityInManifest,
        MissingInternetPermissionInManifest,
        UnknownExceptionRaised
    };
}

