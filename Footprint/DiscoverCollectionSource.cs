using System;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverCollectionSource : UICollectionViewSource
    {
        public Achievements mainPage;

        public FeatureModule featureModule;

        public DiscoverCollectionSource()
        {
            
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return featureModule.GetItemCounts();
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (DiscoverCell)collectionView.DequeueReusableCell("hi", indexPath);
            cell.Initialize(featureModule, indexPath);
            return cell;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            featureModule.OnSelected(indexPath);
        }



    }
}
