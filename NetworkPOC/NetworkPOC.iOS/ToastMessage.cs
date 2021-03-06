﻿using System;
using Foundation;
using NetworkPOC.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace NetworkPOC.iOS
{
    public class ToastMessage:IToast
    {

        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        
        public void ShowToast(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        
    }
}
