using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AdBuddiz.Xamarin;

namespace AndroidSample
{
    [Activity(Label = "AdBuddiz Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			AdBuddizHandler.Instance.SetLogLevel(ABLogLevel.ABLogLevelInfo);
			AdBuddizHandler.Instance.SetPublisherKey(this, "TEST_PUBLISHER_KEY");
			AdBuddizHandler.Instance.SetTestModeActive();
			AdBuddizHandler.Instance.CacheAds();

			Button button = FindViewById<Button>(Resource.Id.button);
			button.Click += delegate
			{
				AdBuddizHandler.Instance.ShowAd();
			};

			AdBuddizHandler.Instance.DidCacheAd += delegate
			{
				Toast.MakeText(this, "DidCasheAd", ToastLength.Short).Show();
			};

			AdBuddizHandler.Instance.DidClick += delegate
			{
				Toast.MakeText(this, "DidClick", ToastLength.Short).Show();
			};

			AdBuddizHandler.Instance.DidShowAd += delegate
			{
				Toast.MakeText(this, "DidShowAd", ToastLength.Short).Show();
			};

			AdBuddizHandler.Instance.DidHideAd += delegate
			{
				Toast.MakeText(this, "DidHideAd", ToastLength.Short).Show();
			};

			AdBuddizHandler.Instance.DidFailToShowAd += (o,e)=>
			{
				Toast.MakeText(this, e.ErrorDescription, ToastLength.Short).Show();
			};
        }
    }
}


