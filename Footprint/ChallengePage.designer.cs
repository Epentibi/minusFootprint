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
	[Register ("ChallengePage")]
	partial class ChallengePage
	{
		[Outlet]
		UIKit.UITableViewCell CellContent { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITableView ChallengeTable { get; set; }

		[Outlet]
		UIKit.UISegmentedControl segmentController { get; set; }

		[Action ("segmentValueChanged:")]
		partial void segmentValueChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CellContent != null) {
				CellContent.Dispose ();
				CellContent = null;
			}

			if (ChallengeTable != null) {
				ChallengeTable.Dispose ();
				ChallengeTable = null;
			}

			if (segmentController != null) {
				segmentController.Dispose ();
				segmentController = null;
			}
		}
	}
}
