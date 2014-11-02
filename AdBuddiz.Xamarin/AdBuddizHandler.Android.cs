using System;
using AdBuddiz.Xamarin;
using Android.App;

namespace AdBuddiz.Xamarin
{
    public class AdBuddizHandler
    {
        class AdBuddizDelegateImpl : Java.Lang.Object, Com.Purplebrain.Adbuddiz.Sdk.IAdBuddizDelegate
        {
            public event EventHandler CacheAd;
            public event EventHandler Click;
            public event EventHandler HideAd;
            public event EventHandler ShowAd;
            public event EventHandler<AdBuddizErrorEventArgs> FailToShowAd;

            public IAdBuddizDelegate Delegate { get; set; }

            public void DidCacheAd()
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

            public void DidClick()
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

            public void DidHideAd()
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

            public void DidShowAd()
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

            public void DidFailToShowAd(Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError error)
            {
                AdBuddizError errorEnum = AdBuddizError.UnsupportedAndroidSdk;

                if( error == Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.ActivityParameterIsNull) errorEnum = AdBuddizError.ActivityParameterIsNull;
                else if(error == Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.ConfigExpired) errorEnum = AdBuddizError.ConfigExpired;
                else if(error == Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.ConfigNotReady) errorEnum = AdBuddizError.ConfigNotReady;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.InvalidPublisherKey) errorEnum = AdBuddizError.InvalidPublisherKey;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.MissingAdbuddizActivityInManifest) errorEnum = AdBuddizError.MissingAdbuddizActivityInManifest;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.MissingInternetPermissionInManifest) errorEnum = AdBuddizError.MissingInternetPermissionInManifest;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.MissingPublisherKey) errorEnum = AdBuddizError.MissingPublisherKey;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.NoMoreAvailableAds) errorEnum = AdBuddizError.NoMoreAvailableAds;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.NoMoreAvailableCachedAds) errorEnum = AdBuddizError.NoMoreAvailableCachedAds;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.NoNetworkAvailable) errorEnum = AdBuddizError.NoNetworkAvailable;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.PlacementBlocked) errorEnum = AdBuddizError.PlacementBlocked;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.ShowAdCallsTooClose) errorEnum = AdBuddizError.ShowAdCallsTooClose;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.UnknownExceptionRaised) errorEnum = AdBuddizError.UnknownExceptionRaised;
                else if(error ==  Com.Purplebrain.Adbuddiz.Sdk.AdBuddizError.UnsupportedAndroidSdk) errorEnum = AdBuddizError.UnsupportedAndroidSdk;

                if (FailToShowAd != null) 
                {
                    FailToShowAd(this, new AdBuddizErrorEventArgs(errorEnum));
                }

                if (Delegate != null) 
                {
                    Delegate.DidFailToShowAd(errorEnum);
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

        private Activity _activity = null;

        private AdBuddizHandler()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.Delegate = _delegate;
        }

        public void SetLogLevel(ABLogLevel level)
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddizLogLevel logLevel = Com.Purplebrain.Adbuddiz.Sdk.AdBuddizLogLevel.Silent;

            switch(level)
            {
            case ABLogLevel.ABLogLevelError:
                logLevel = Com.Purplebrain.Adbuddiz.Sdk.AdBuddizLogLevel.Error;
                break;

            case ABLogLevel.ABLogLevelInfo:
                logLevel = Com.Purplebrain.Adbuddiz.Sdk.AdBuddizLogLevel.Info;
                break;
            }

            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.SetLogLevel(logLevel);
        }

        public void SetPublisherKey(Activity activity, string publisherKey)
        {
            _activity = activity;
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.SetPublisherKey(publisherKey);
        }

        public void SetTestModeActive()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.SetTestModeActive();
        }

        public void CacheAds()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.CacheAds(_activity);
        }

        public bool IsReadyToShowAd 
        {
            get 
            {
                return Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.IsReadyToShowAd(_activity);
            }
        }

        public bool IsReadyToShowAdWithPlacement(string placement)
        {
            return Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.IsReadyToShowAd(_activity, placement);
        }

        public void ShowAd()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.ShowAd(_activity);
        }

        public void ShowAd(string placement)
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.ShowAd(_activity, placement);
        }

        public void SetDelegate(IAdBuddizDelegate delegateObj)
        {
            _delegate.Delegate = delegateObj;
        }

        public String NameForError(AdBuddizError error)
        {
            return error.ToString();
        }
    }
}

