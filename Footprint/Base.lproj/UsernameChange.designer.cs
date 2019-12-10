// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Footprint.Base.lproj
{
    [Register ("UsernameChange")]
    partial class UsernameChange
    {
        [Outlet]
        UIKit.UITextField usernameField { get; set; }


        [Action ("complete:")]
        partial void complete (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}