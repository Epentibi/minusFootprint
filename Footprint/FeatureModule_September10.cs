using System;
using Foundation;
using CoreGraphics;
using UIKit;

namespace Footprint
{
    public class FeatureModule_September10 : FeatureModule
    {
        public FeatureModule_September10()
        {
        }


        public override DiscoverCell GetCellAd(NSIndexPath indexPath, CGRect rect)
        {
            return new DiscoverCell(rect);
        }

        public override int GetItemCounts()
        {
            return 3;
        }

        public override int getType(NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                return 1;
            }
            else if (indexPath.Row == 1)
            {
                return 1;
            }
            else if (indexPath.Row == 2)
            {
                return 1;
            }
            return 1;
        }

        public override string Title(NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                return NSBundle.MainBundle.GetLocalizedString("Visit Our Website");
            }
            else if (indexPath.Row == 1)
            {
                return NSBundle.MainBundle.GetLocalizedString("Popular Challenges");
            }
            else if (indexPath.Row == 2)
            {
                return NSBundle.MainBundle.GetLocalizedString("Browse Challenges");
            }

            return "Test";
        }

        public override string SubTitle(NSIndexPath indexPath)
        {
            return "Test";
        }

        public override UIImage image(NSIndexPath indexPath)
        {
            if(indexPath.Row == 0)
            {
                return UIImage.FromFile("Image/MinusFootPrint Icon Alpha.png");
            }
            else if (indexPath.Row == 1)
            {
                return UIImage.FromFile("Image/Discover/Challenge.png");
            }
            else if (indexPath.Row == 2)
            {
                return UIImage.FromFile("Image/Challenge/Challenges.png");
            }

            return UIImage.FromFile("Image/ChallengeArt/FoodWaste.png");
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            if (indexPath.Row == 0)
            {
                return 9;
            }
            else if (indexPath.Row == 1)
            {
                return 4;
            }
            else if (indexPath.Row == 2)
            {
                return 0;
            }

            return 0;
        }

        public override void OnSelected(NSIndexPath indexPath)
        {
            if(indexPath.Row == 0)
            {
                UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.minusfootprint.com"));
            }
            else if (indexPath.Row == 1)
            {
                foreach(DiscoverModule d in modules)
                {
                    if(d is DiscoverTopPickModule)
                    {
                        discoverPage.expand(d);
                        return;
                    }
                }
            }
            else if (indexPath.Row == 2)
            {
                System.Diagnostics.Debug.WriteLine("hehe");
                ChallengePage challengeTotal = discoverPage.NavigationController.Storyboard.InstantiateViewController("ChallengePage") as ChallengePage;
                discoverPage.NavigationController.PushViewController(challengeTotal, true);
            }
        }
    }
}
