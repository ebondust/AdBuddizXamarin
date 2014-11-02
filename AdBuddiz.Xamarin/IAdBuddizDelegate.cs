using System;

namespace AdBuddiz.Xamarin
{
   public interface IAdBuddizDelegate
   {
      void DidCacheAd();

      void DidShowAd();

      void DidFailToShowAd(AdBuddizError error);

      void DidClick();

      void DidHideAd();
   }
}

