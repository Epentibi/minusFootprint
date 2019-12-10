// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Footprint.Base.lproj
{
	[Register ("Discover")]
	partial class Discover
	{
		[Outlet]
		UIKit.UICollectionView CollectionViewTest { get; set; }

		[Outlet]
		UIKit.UIStackView rootStackView { get; set; }

		[Outlet]
		UIKit.UICollectionView smallCollectionView { get; set; }

		[Action ("wechatConnect:")]
		partial void wechatConnect (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CollectionViewTest != null) {
				CollectionViewTest.Dispose ();
				CollectionViewTest = null;
			}

			if (smallCollectionView != null) {
				smallCollectionView.Dispose ();
				smallCollectionView = null;
			}

			if (rootStackView != null) {
				rootStackView.Dispose ();
				rootStackView = null;
			}
		}
	}
}
