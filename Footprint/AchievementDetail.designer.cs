// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Footprint
{
    [Register ("AchievementDetail")]
    partial class AchievementDetail
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AchievementPreview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Description { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView ProgressBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationItem TopBar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AchievementPreview != null) {
                AchievementPreview.Dispose ();
                AchievementPreview = null;
            }

            if (Description != null) {
                Description.Dispose ();
                Description = null;
            }

            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }

            if (ProgressBar != null) {
                ProgressBar.Dispose ();
                ProgressBar = null;
            }

            if (TopBar != null) {
                TopBar.Dispose ();
                TopBar = null;
            }
        }
    }
}