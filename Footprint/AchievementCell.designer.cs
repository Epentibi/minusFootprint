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
    [Register ("AchievementCell")]
    partial class AchievementCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Preview { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SecondayLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MainLabel != null) {
                MainLabel.Dispose ();
                MainLabel = null;
            }

            if (Preview != null) {
                Preview.Dispose ();
                Preview = null;
            }

            if (SecondayLabel != null) {
                SecondayLabel.Dispose ();
                SecondayLabel = null;
            }
        }
    }
}