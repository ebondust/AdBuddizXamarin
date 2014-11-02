using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using AdBuddiz.Xamarin;

namespace AdBuddiz.Xamarin.Internal
{
   [BaseType (typeof (NSObject))]
   interface AdBuddiz
   {
      [Static]
      [Export ("setLogLevel:")]
      void SetLogLevel(ABLogLevel level);

      [Static]
      [Export ("setPublisherKey:")]
      void SetPublisherKey(string publisherKey);

      [Static]
      [Export ("setTestModeActive")]
      void SetTestModeActive();

      [Static]
      [Export ("cacheAds")]
      void CacheAds();

      [Static]
      [Export ("isReadyToShowAd")]
      bool IsReadyToShowAd();

      [Static]
      [Export ("isReadyToShowAd:")]
      bool IsReadyToShowAd(string placement);

      [Static]
      [Export ("showAd")]
      void ShowAd();

      [Static]
      [Export ("showAd:")]
      void ShowAd(string placement);

      [Static]
      [Export ("setDelegate:")]
      void SetDelegate(AdBuddizDelegate delegateObj);

      [Static]
      [Export ("nameForError:")]
      string NameForError(AdBuddizError error);
   }
}

