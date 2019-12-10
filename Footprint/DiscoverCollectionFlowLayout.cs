using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace Footprint
{
    public class DiscoverCollectionFlowLayout : UICollectionViewDelegateFlowLayout
    {

        public nfloat PageWidth;
        public int itemCount;
        UICollectionView collectionview;

        int _currentPageIndex = 0;

         public DiscoverCollectionFlowLayout(UICollectionView view)
        {
            PageWidth = view.Frame.Width;
            itemCount = (int)view.NumberOfItemsInSection(0);
            collectionview = view;
            //view.PagingEnabled = false;
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            return new CGSize(collectionView.Frame.Width - 16 * 2, collectionView.Frame.Height - 8 * 2);
        }

        public override UIEdgeInsets GetInsetForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return new UIEdgeInsets(0, 16, 0, 16);
        }

        public override nfloat GetMinimumLineSpacingForSection(UICollectionView collectionView, UICollectionViewLayout layout, nint section)
        {
            return 8;
        }

        public override void WillEndDragging(UIScrollView scrollView, CGPoint velocity, ref CGPoint targetContentOffset)
        {
            nfloat pageWidth = collectionview.Frame.Width - 16 * 2 + 8;
            int newPageIndex;

            if (velocity.X > 0)
            {
                nfloat contentWidthWithoutCollectionMargins = scrollView.ContentSize.Width - 2 * 16;
                var maxPageIndex = (int)Math.Ceiling(contentWidthWithoutCollectionMargins / pageWidth) - 1;
                newPageIndex = Math.Min(_currentPageIndex + 1, maxPageIndex);
            }
            else if (velocity.X == 0)
            {
                newPageIndex = (int)Math.Floor((targetContentOffset.X - pageWidth / 2) / pageWidth) + 1;
            }
            else
            {
                var minPageIndex = 0;
                newPageIndex = Math.Max(_currentPageIndex - 1, minPageIndex);
            }

            _currentPageIndex = newPageIndex;
            targetContentOffset = new CGPoint(newPageIndex * pageWidth, targetContentOffset.Y);
        }

        /*
       public override void WillEndDragging(UIScrollView scrollView, CGPoint velocity, ref CGPoint targetContentOffset)
       {
           var factor = 0.5f;
           if(velocity.X < 0)
           {
               factor = -factor;
               System.Diagnostics.Debug.WriteLine("right");
           }
           else
           {
               System.Diagnostics.Debug.WriteLine("left");
           }

           float a = (float)(scrollView.ContentOffset.X / PageWidth);
           var index = (int)MathF.Round(a + factor);
           if(index < 0)
           {
               index = 0;
           }
           else if(index > itemCount - 1)
           {
               index = (int)(itemCount - 1);
           }
           System.Diagnostics.Debug.WriteLine("index is " + index);
           var indexPath = NSIndexPath.FromRowSection(index, 0);
           collectionview.ScrollToItem(indexPath, UICollectionViewScrollPosition.CenteredHorizontally, true);

       }*/


    }
}
