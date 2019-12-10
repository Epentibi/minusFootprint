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
    [Register ("CustomCellLabel")]
    partial class CustomCellLabel
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView mainicon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel mainlabel { get; set; }

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
        }
    }
}