using System;
using Foundation;
using UIKit;

namespace Footprint
{
    public class SmalleDiscoverCollectionSource : UICollectionViewSource
    {
        public DiscoverModule discoverModule;

        public SmalleDiscoverCollectionSource(DiscoverModule module)
        {
            discoverModule = module;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return discoverModule.getRowCount();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (SmallDiscoverCell)collectionView.DequeueReusableCell("hi", indexPath);
            cell.Initialize(discoverModule, indexPath);
            return cell;
        }



    }
}
