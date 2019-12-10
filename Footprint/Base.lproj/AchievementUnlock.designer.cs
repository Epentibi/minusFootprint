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
    [Register ("AchievementUnlock")]
    partial class AchievementUnlock
    {
        [Outlet]
        UIKit.UILabel achievementName { get; set; }


        [Outlet]
        UIKit.UIImageView achievementPreview { get; set; }


        [Outlet]
        UIKit.UIButton bottom { get; set; }


        [Action ("debugButtom:")]
        partial void debugButtom (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}