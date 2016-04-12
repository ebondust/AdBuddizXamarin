using System;
using AdBuddiz.Xamarin;
using Android.App;

namespace AdBuddiz.Xamarin
{
    public class AdBuddizHandler
    {
        class AdBuddizDelegateImpl : Java.Lang.Object, Com.Purplebrain.Adbuddiz.Sdk.IAdBuddizDelegate, Com.Purplebrain.Adbuddiz.Sdk.IAdBuddizRewardedVideoDelegate
        {
            public event EventHandler CacheAd;
            public event EventHandler Click;
            public event EventHandler HideAd;
            public event EventHandler ShowAd;

            //rewardedVideo handlers
            public event EventHandler Complete;
           // public event EventHandler Fail;
            public event EventHandler Fetch;
            public event EventHandler NotComplete;

            public event EventHandler<AdBuddizErrorEventArgs> FailToShowAd;

            public IAdBuddizDelegate Delegate { get; set; }
            public IAdBuddizRewardedVideoDelegate DelegateR { get; set; }

            public void DidCacheAd()
            {
                CacheAd?.Invoke(this, EventArgs.Empty);

                if (Delegate != null) 
                {
                    Delegate.DidCacheAd();
                }
            }

            public void DidClick()
            {
                Click?.Invoke(this, EventArgs.Empty);

                if (Delegate != null) 
                {
                    Delegate.DidClick();
                }
            }

            public void DidHideAd()
            {
                HideAd?.Invoke(this, EventArgs.Empty);

                if (Delegate != null) 
                {
                    Delegate.DidHideAd();
                }
            }

            public void DidShowAd()
            {
                ShowAd?.Invoke(this, EventArgs.Empty);

                if (Delegate != null) 
                {
                    Delegate.DidShowAd();
                }
            }


            // rewarded video
            public void DidComplete()
            {
                Complete?.Invoke(this, EventArgs.Empty);

                if (Delegate != null)
                {
                    DelegateR.DidComplete();
                }
            }

            public void DidFail(Com.Purplebrain.Adbuddiz.Sdk.AdBuddizRewardedVideoError p0)
            {
                //throw new NotImplementedException();
            }

            public void DidFetch()
            {
                Fetch?.Invoke(this, EventArgs.Empty);

                if (Delegate != null)
                {
                    DelegateR.DidFetch();
                }
            }

            public void DidNotComplete()
            {
                NotComplete?.Invoke(this, EventArgs.Empty);

                if (Delegate != null)
                {
                    DelegateR.DidNotComplete();
                }
            }

            //end


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

                FailToShowAd?.Invoke(this, new AdBuddizErrorEventArgs(errorEnum));

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


        // rewarded ads

        public event EventHandler DidComplete
        {
            add
            {
                _delegate.Complete += value;
            }

            remove
            {
                _delegate.Complete -= value;
            }
        }

        public event EventHandler DidFetch
        {
            add
            {
                _delegate.Fetch += value;
            }

            remove
            {
                _delegate.Fetch -= value;
            }
        }

       

        public event EventHandler DidNotComplete
        {
            add
            {
                _delegate.NotComplete += value;
            }

            remove
            {
                _delegate.NotComplete -= value;
            }
        }

        private AdBuddizDelegateImpl _delegate = new AdBuddizDelegateImpl();

        private Activity _activity = null;

        private AdBuddizHandler()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.Delegate = _delegate;
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.RewardedVideo.Delegate = _delegate;
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

        public void SetPublisherKey(string publisherKey)
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.SetPublisherKey(publisherKey);
        }

        public void SetTestModeActive()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.SetTestModeActive();
        }

		public void CacheAds(Activity activity)
        {
			_activity = activity;
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.CacheAds(_activity);
        }

        public void FetchRewardedAds(Activity activity)
        {
            _activity = activity;
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.RewardedVideo.Fetch(_activity);
        }

        public bool IsReadyToShowAd 
        {
            get 
            {
                return Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.IsReadyToShowAd(_activity);
            }
        }

        public bool IsReadyToShowRewardedAd
        {
            get
            {
                return Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.RewardedVideo.IsReadyToShow(_activity);
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

        public void ShowRewardedAd()
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.RewardedVideo.Show(_activity);
        }

        public void ShowAd(string placement)
        {
            Com.Purplebrain.Adbuddiz.Sdk.AdBuddiz.ShowAd(_activity, placement);
        }

        public void SetDelegate(IAdBuddizDelegate delegateObj)
        {
            _delegate.Delegate = delegateObj;
            
        }
        public void SetDelegate(IAdBuddizRewardedVideoDelegate delegateObj)
        {
            _delegate.DelegateR = delegateObj;
        }

        public String NameForError(AdBuddizError error)
        {
            return error.ToString();
        }


      

    }
}

