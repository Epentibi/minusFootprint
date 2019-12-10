using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverTipsModule : DiscoverModule
    {

        int randomoffSet = 0;

        public DiscoverTipsModule(List<TipLibrary.Tip> getTips)
        {
            tips = getTips;

            randomoffSet = new Random().Next(int.MinValue, int.MaxValue);
        }

        public List<TipLibrary.Tip> tips = new List<TipLibrary.Tip>();

        public override UIImage getImage(NSIndexPath indexPath)
        {
            return imageManager.iconOfIndex(tips[indexPath.Row].ConditionIndex);
        }

        public override string getName(NSIndexPath indexPath)
        {
            return tips[indexPath.Row].TipName;
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            return tips[indexPath.Row].ConditionIndex;
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            int imageIndex = new Random(indexPath.Row + randomoffSet).Next(0, 6);

            TipDaily f = mainController.Storyboard.InstantiateViewController("TipDaily") as TipDaily;
            f.thisTip = tips[indexPath.Row];
            f.imageIndex = imageIndex;
            f.controller = mainController;
            mainController.PresentViewController(f, true, null);
        }

        public override int getRowCount()
        {
            return tips.Count;
        }

        public override bool addButtomVisibility()
        {
            return false;
        }
    }
}
