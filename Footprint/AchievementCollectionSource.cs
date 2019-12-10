using System;
using Foundation;
using UIKit;
using System.Collections.Generic;

namespace Footprint
{
    public class AchievementCollectionSource : UICollectionViewSource
    {
        List<AchievementManager.AchievementConfig> achievement = new List<AchievementManager.AchievementConfig>();
        public Achievements mainPage;

        public AchievementCollectionSource(List<AchievementManager.AchievementConfig> achievements, Achievements p)
        {
            mainPage = p;
            achievement = achievements;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return achievement.Count;
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            AchievementDetail detail = mainPage.Storyboard.InstantiateViewController("DetailPage") as AchievementDetail;
            mainPage.NavigationController.PushViewController(detail, true);
            detail.achievement = achievement[indexPath.Row];
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(AchievementCell.CellID, indexPath) as AchievementCell;
            bool State = false;

            if(AchievementManager.getConfig(achievement[indexPath.Row].AchievementID) != null)
            {
                State = AchievementManager.getConfig(achievement[indexPath.Row].AchievementID).Unlocked;
            }

            cell.UpdateCell(achievement[indexPath.Row].AchievementName, State, UIImage.FromFile("Image/Achievements/" + achievement[indexPath.Row].ImageName));
            return cell;
        }
    }
}
