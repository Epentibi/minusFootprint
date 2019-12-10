using System;
using Foundation;
using CoreGraphics;
using UIKit;
using System.Collections.Generic;
using Footprint.Base.lproj;

namespace Footprint
{
    public class FeatureModule
    {
        public List<DiscoverModule> modules = new List<DiscoverModule>();
        public Discover discoverPage;

        public virtual void OnSelected(NSIndexPath indexPath)
        {

        }

        public virtual DiscoverCell GetCellAd(NSIndexPath indexPath, CGRect rect)
        {
            return new DiscoverCell(rect);
        }

        public virtual int GetItemCounts()
        {
            return 3;
        }

        public virtual int getType(NSIndexPath indexPath)
        {
            return 1;
        }

        public virtual string Title(NSIndexPath indexPath)
        {
            return "Test";
        }

        public virtual string SubTitle(NSIndexPath indexPath)
        {
            return "Test";
        }

        public virtual UIImage image(NSIndexPath indexPath)
        {
            return UIImage.FromFile("Image/ChallengeArt/FoodWaste.png");
        }

        public virtual int getColorCode(NSIndexPath indexPath)
        {
            return 0;
        }
    }
}
