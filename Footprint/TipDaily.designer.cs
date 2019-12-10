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
    [Register ("TipDaily")]
    partial class TipDaily
    {
        [Outlet]
        UIKit.UIImageView Background { get; set; }


        [Outlet]
        UIKit.UITextView Description { get; set; }


        [Outlet]
        UIKit.UIImageView Icon { get; set; }


        [Outlet]
        UIKit.UILabel Title { get; set; }


        [Outlet]
        UIKit.UINavigationItem TopBar { get; set; }


        [Action ("done:")]
        partial void done (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}