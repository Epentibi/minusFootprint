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
	[Register ("About")]
	partial class About
	{
		[Outlet]
		UIKit.UITextView AboutText { get; set; }

		[Outlet]
		UIKit.UITextView CopyrightText { get; set; }

		[Outlet]
		UIKit.UILabel VersionText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AboutText != null) {
				AboutText.Dispose ();
				AboutText = null;
			}

			if (CopyrightText != null) {
				CopyrightText.Dispose ();
				CopyrightText = null;
			}

			if (VersionText != null) {
				VersionText.Dispose ();
				VersionText = null;
			}
		}
	}
}
