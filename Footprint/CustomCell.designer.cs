// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Footprint
{
    [Register ("CustomCell")]
    partial class CustomCell
    {
        [Outlet]
        UIKit.UIImageView background { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView mainicon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel mainlabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel secondaryLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (mainicon != null) {
                mainicon.Dispose ();
                mainicon = null;
            }

            if (mainlabel != null) {
                mainlabel.Dispose ();
                mainlabel = null;
            }

            if (secondaryLabel != null) {
                secondaryLabel.Dispose ();
                secondaryLabel = null;
            }
        }
    }
}