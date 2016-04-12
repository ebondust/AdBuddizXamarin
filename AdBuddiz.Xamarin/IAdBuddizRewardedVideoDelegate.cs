using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AdBuddiz.Xamarin
{
    public interface IAdBuddizRewardedVideoDelegate
    {
        void DidComplete();    // user fully watched the video, give the reward here 

       
        void DidFetch();       // a video is ready to be displayed
      
        void DidNotComplete(); // an error happened during video playback
    }
}