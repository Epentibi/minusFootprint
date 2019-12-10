using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class Achievements : UIViewController
    {
        public Achievements (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var achievementsSource = new AchievementCollectionSource(AchievementManager.achievements, this);
            collectionView.Source = achievementsSource;

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var achievementsSource = new AchievementCollectionSource(AchievementManager.achievements, this);
            collectionView.Source = achievementsSource;
        }
    }
}