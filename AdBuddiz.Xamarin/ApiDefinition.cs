using System;
using System.Drawing;
using ObjCRuntime;
using Foundation;
using UIKit;
using AdBuddiz.Xamarin;

namespace AdBuddiz.Xamarin.Internal
{
   [BaseType (typeof (NSObject))]
   interface AdBuddiz
   {
      [Static]
      [Export ("setLogLevel:")]
      void SetLogLevel(int level);

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
      void SetDelegate(NSObject delegateObj);

      [Static]
      [Export ("nameForError:")]
      string NameForError(int error);
   }
}

