using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverBrowseModule : DiscoverModule
    {

        public DiscoverBrowseModule()
        {
            secondaryHeader = NSBundle.MainBundle.GetLocalizedString("Browse all by type");
        }

        public override UIImage getImage(NSIndexPath indexPath)
        {
            int row = indexPath.Row;
            var imagePath = "Image/Discover/";

            switch (row)
            {
                case 0:
                    imagePath += "Challenge.png";
                    break;
                case 1:
                    imagePath += "Article.png";
                    break;
                case 2:
                    imagePath += "Tip.png";
                    break;
            }

            return UIImage.FromFile(imagePath);
        }

        public override string getName(NSIndexPath indexPath)
        {
            int row = indexPath.Row;
            var name = "Not Implemented";

            switch (row)
            {
                case 0:
                    name = NSBundle.MainBundle.GetLocalizedString("Challenges");
                    break;
                case 1:
                    name = NSBundle.MainBundle.GetLocalizedString("Articles");
                    break;
                case 2:
                    name = NSBundle.MainBundle.GetLocalizedString("Tips");
                    break;
            }

            return name;
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            return 0;
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            if(indexPath.Row == 0)
            {
                ChallengePage challengeTotal = mainController.Storyboard.InstantiateViewController("ChallengePage") as ChallengePage;
                mainController.PushViewController(challengeTotal, true);
            }
        }

        public override int getRowCount()
        {
            return 3;
        }

        public override bool addButtomVisibility()
        {
            return false;
        }

        public override bool secondaryHeaderVisibility()
        {
            return true;
        }

        public override bool expansionButtonVisibility()
        {
            return false;
        }
    }
}
