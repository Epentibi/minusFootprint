// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Footprint
{
	[Register ("DailyChallenge")]
	partial class DailyChallenge
	{
		[Outlet]
		UIKit.UIView AchievementView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView ChallengeArt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView ConditionIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel ConditionLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextView Description { get; set; }

		[Outlet]
		UIKit.UIImageView Icon { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem nav_done { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton TickButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UINavigationItem TopBar { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView TypeIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel TypeLabel { get; set; }

		[Action ("Done:")]
		partial void Done (Foundation.NSObject sender);

		[Action ("TickButton_TouchUpInside:")]
		partial void TickButton_TouchUpInside (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nav_done != null) {
				nav_done.Dispose ();
				nav_done = null;
			}

			if (AchievementView != null) {
				AchievementView.Dispose ();
				AchievementView = null;
			}

			if (Icon != null) {
				Icon.Dispose ();
				Icon = null;
			}

			if (ChallengeArt != null) {
				ChallengeArt.Dispose ();
				ChallengeArt = null;
			}

			if (ConditionIcon != null) {
				ConditionIcon.Dispose ();
				ConditionIcon = null;
			}

			if (ConditionLabel != null) {
				ConditionLabel.Dispose ();
				ConditionLabel = null;
			}

			if (Description != null) {
				Description.Dispose ();
				Description = null;
			}

			if (TickButton != null) {
				TickButton.Dispose ();
				TickButton = null;
			}

			if (TopBar != null) {
				TopBar.Dispose ();
				TopBar = null;
			}

			if (TypeIcon != null) {
				TypeIcon.Dispose ();
				TypeIcon = null;
			}

			if (TypeLabel != null) {
				TypeLabel.Dispose ();
				TypeLabel = null;
			}
		}
	}
}
