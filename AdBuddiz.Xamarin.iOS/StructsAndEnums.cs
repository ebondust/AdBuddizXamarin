using System;
using MonoTouch.Foundation;

namespace AdBuddiz.Xamarin.Ios
{
   public enum ABLogLevel
   {
      ABLogLevelInfo = 1,
      ABLogLevelError = 2,
      ABLogLevelSilent = 0
   };

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
      UnknownExceptionRaised = 999
   };

   namespace Internal
   {
      [Register ("AdBuddizDelegate"), Model]
      public abstract class AdBuddizDelegate : NSObject
      {
         [Export ("didCacheAd")]
         protected virtual void DidCacheAd(){}

         [Export ("didShowAd")]
         protected virtual void DidShowAd(){}

         [Export ("didFailToShowAd:")]
         protected virtual void DidFailToShowAd(AdBuddizError error){}

         [Export ("didClick")]
         protected virtual void DidClick(){}

         [Export ("didHideAd")]
         protected virtual void DidHideAd(){}
      }
   }
}

