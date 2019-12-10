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
    [Register ("ChallengeComplete")]
    partial class ChallengeComplete
    {
        [Outlet]
        UIKit.UIImageView AchievementPreview { get; set; }


        [Outlet]
        UIKit.UIButton ChallengeButtom { get; set; }


        [Outlet]
        UIKit.UIImageView ChallengeImage { get; set; }


        [Outlet]
        UIKit.UILabel ChallengeName { get; set; }


        [Outlet]
        UIKit.UILabel complete { get; set; }


        [Outlet]
        UIKit.UILabel quotes { get; set; }


        [Outlet]
        UIKit.UIStackView stackView { get; set; }


        [Outlet]
        UIKit.UIView toAchievement { get; set; }


        [Outlet]
        UIKit.UILabel ToNextAchievement_Label { get; set; }


        [Outlet]
        UIKit.UILabel TotalChallengeCompletetion { get; set; }


        [Action ("done:")]
        partial void done (Foundation.NSObject sender);


        [Action ("SubmitComplete:")]
        partial void SubmitComplete (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}