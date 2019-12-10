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
	[Register ("ChallengeDetail")]
	partial class ChallengeDetail
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton AddButton { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem cancel_nav { get; set; }

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
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UINavigationItem TopLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIImageView TypeIcon { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel TypeLabel { get; set; }

		[Action ("Add:")]
		partial void Add (Foundation.NSObject sender);

		[Action ("AddButton_TouchUpInside:")]
		partial void AddButton_TouchUpInside (UIKit.UIButton sender);

		[Action ("cancelView:")]
		partial void cancelView (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Icon != null) {
				Icon.Dispose ();
				Icon = null;
			}

			if (AddButton != null) {
				AddButton.Dispose ();
				AddButton = null;
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

			if (TopLabel != null) {
				TopLabel.Dispose ();
				TopLabel = null;
			}

			if (TypeIcon != null) {
				TypeIcon.Dispose ();
				TypeIcon = null;
			}

			if (TypeLabel != null) {
				TypeLabel.Dispose ();
				TypeLabel = null;
			}

			if (cancel_nav != null) {
				cancel_nav.Dispose ();
				cancel_nav = null;
			}
		}
	}
}
