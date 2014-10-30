using System;
using MonoTouch.Foundation;
using AdBuddiz.Xamarin.Ios;

namespace AdBuddiz.Xamarin.Ios
{
    public class AdBuddizHandler
    {
        class AdBuddizDelegateImpl : AdBuddiz.Xamarin.Ios.Internal.AdBuddizDelegate
        {
            public event EventHandler CacheAd;
            public event EventHandler Click;
            public event EventHandler HideAd;
            public event EventHandler ShowAd;
            public event EventHandler<AdBuddizErrorEventArgs> FailToShowAd;

            public IAdBuddizDelegate Delegate { get; set; }

            protected override void DidCacheAd()
            {
                if (CacheAd != null) 
                {
                    CacheAd(this, EventArgs.Empty);
                }

                if (Delegate != null) 
                {
                    Delegate.DidCacheAd();
                }
            }

            protected override void DidClick()
            {
                if (Click != null) 
                {
                    Click(this, EventArgs.Empty);
                }

                if (Delegate != null) 
                {
                    Delegate.DidClick();
                }
            }

            protected override void DidHideAd()
            {
                if (HideAd != null) 
                {
                    HideAd(this, EventArgs.Empty);
                }

                if (Delegate != null) 
                {
                    Delegate.DidHideAd();
                }
            }

            protected override void DidShowAd()
            {
                if (ShowAd != null) 
                {
                    ShowAd(this, EventArgs.Empty);
                }

                if (Delegate != null) 
                {
                    Delegate.DidShowAd();
                }
            }

            protected override void DidFailToShowAd(AdBuddizError error)
            {
                if (FailToShowAd != null) 
                {
                    FailToShowAd(this, new AdBuddizErrorEventArgs(error));
                }

                if (Delegate != null) 
                {
                    Delegate.DidFailToShowAd(error);
                }
            }
        }

        public static readonly AdBuddizHandler Instance = new AdBuddizHandler();

        public event EventHandler DidCacheAd 
        {
            add 
            {
                _delegate.CacheAd += value;
            }

            remove 
            {
                _delegate.CacheAd -= value;
            }
        }

        public event EventHandler DidClick 
        {
            add 
            {
                _delegate.Click += value;
            }

            remove 
            {
                _delegate.Click -= value;
            }
        }

        public event EventHandler DidHideAd 
        {
            add 
            {
                _delegate.HideAd += value;
            }

            remove 
            {
                _delegate.HideAd -= value;
            }
        }

        public event EventHandler DidShowAd 
        {
            add 
            {
                _delegate.ShowAd += value;
            }

            remove 
            {
                _delegate.ShowAd -= value;
            }
        }

        public event EventHandler<AdBuddizErrorEventArgs> DidFailToShowAd 
        {
            add 
            {
                _delegate.FailToShowAd += value;
            }

            remove 
            {
                _delegate.FailToShowAd -= value;
            }
        }

        private AdBuddizDelegateImpl _delegate = new AdBuddizDelegateImpl();

        private AdBuddizHandler()
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.SetDelegate(_delegate);
        }

        public void SetLogLevel(ABLogLevel level)
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.SetLogLevel(level);
        }

        public void SetPublisherKey(string publisherKey)
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.SetPublisherKey(publisherKey);
        }

        public void SetTestModeActive()
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.SetTestModeActive();
        }

        public void CacheAds()
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.CacheAds();
        }

        public bool IsReadyToShowAd 
        {
            get 
            {
                return AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.IsReadyToShowAd();
            }
        }

        public bool IsReadyToShowAdWithPlacement(string placement)
        {
            return AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.IsReadyToShowAd(placement);
        }

        public void ShowAd()
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.ShowAd();
        }

        public void ShowAd(string placement)
        {
            AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.ShowAd(placement);
        }

        public void SetDelegate(IAdBuddizDelegate delegateObj)
        {
            _delegate.Delegate = delegateObj;
        }

        public String NameForError(AdBuddizError error)
        {
            return AdBuddiz.Xamarin.Ios.Internal.AdBuddiz.NameForError(error);
        }
    }
}

