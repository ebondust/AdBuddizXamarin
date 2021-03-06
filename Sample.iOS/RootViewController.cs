﻿
using System;
using System.Drawing;

using Foundation;
using UIKit;
using AdBuddiz.Xamarin;

namespace Sample.iOs
{
    public partial class RootViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            UIButton showAdButton = new UIButton(UIButtonType.RoundedRect);

            showAdButton.Frame = new RectangleF(30, 30, 100, 50);
            showAdButton.SetTitle("Show Ad", UIControlState.Normal);

            showAdButton.TouchUpInside += delegate
            {
                AdBuddizHandler.Instance.ShowAd();
            };

            Add(showAdButton);
        }
    }
}

