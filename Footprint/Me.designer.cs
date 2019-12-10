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
    [Register ("Me")]
    partial class Me
    {
        [Outlet]
        UIKit.UILabel Name { get; set; }


        [Outlet]
        UIKit.UIImageView ProfilePic { get; set; }


        [Outlet]
        UIKit.UITableView Table { get; set; }


        [Outlet]
        UIKit.UILabel username { get; set; }


        [Action ("changeUsername:")]
        partial void changeUsername (Foundation.NSObject sender);


        [Action ("NameTap:")]
        partial void NameTap (Foundation.NSObject sender);


        [Action ("OnNameInput:")]
        partial void OnNameInput (Foundation.NSObject sender);


        [Action ("ProfileTap:")]
        partial void ProfileTap (Foundation.NSObject sender);


        [Action ("survey:")]
        partial void survey (Foundation.NSObject sender);


        [Action ("tap:")]
        partial void tap (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}