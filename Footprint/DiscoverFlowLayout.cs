using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace Footprint
{
    public class DiscoverFlowLayout : UICollectionViewFlowLayout
    {
        public DiscoverFlowLayout()
        {
            ScrollDirection = UICollectionViewScrollDirection.Horizontal;
        }

        public override UICollectionViewLayoutInvalidationContext GetInvalidationContextForBoundsChange(CGRect newBounds)
        {
            var context = (UICollectionViewFlowLayoutInvalidationContext)base.GetInvalidationContextForBoundsChange(newBounds);

            context.InvalidateFlowLayoutDelegateMetrics = newBounds != CollectionView.Bounds;

            return context;
        }
    }
}
