using Foundation;
using System;
using UIKit;
using CoreGraphics;

namespace Footprint
{
    public partial class AchievementCell : UICollectionViewCell
    {

        

        public static NSString CellID = new NSString("AchievementCell");
        public AchievementCell (IntPtr handle) : base (handle)
        {

        }

        public void UpdateCell(string Name, bool UnlockState, UIImage image)
        {
            MainLabel.Text = Name;
            if (UnlockState)
            {
                SecondayLabel.Text = NSBundle.MainBundle.GetLocalizedString("UNLOCKED");
                Preview.Image = image;
            }
            else
            {
                SecondayLabel.Text = NSBundle.MainBundle.GetLocalizedString("LOCKED");
                Preview.Image = UIImage.FromFile("Image/Achievements/" + "null.png");

            }
        }
    }
}