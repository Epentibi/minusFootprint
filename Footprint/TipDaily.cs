using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class TipDaily : UIViewController
    {
        public TipDaily (IntPtr handle) : base (handle)
        {
        }

        public TipLibrary.Tip thisTip;
        public UINavigationController controller;
        public int imageIndex;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
             Background.Image = UIImage.FromFile("Image/ChallengeTopic/" + thisTip.ConditionIndex.ToString() + "/" + imageIndex.ToString() + ".jpg");
            int condition = thisTip.ConditionIndex;

            string iconPath = "Image/Challenge/";

            if (condition == 0)
            {
                iconPath += "FoodSource.png";
            }
            else if (condition == 1)
            {
                iconPath += "FoodPrice.png";
            }
            else if (condition == 2)
            {
                iconPath += "FoodWaste.png";
            }
            else if (condition == 3)
            {
                iconPath += "DailyTransport.png";
            }
            else if (condition == 4)
            {
                iconPath += "OccasionalTransport.png";
            }
            else if (condition == 5)
            {
                iconPath += "PaperUsage.png";
            }
            else if (condition == 6)
            {
                iconPath += "PlasticUsage.png";
            }
            else if (condition == 7)
            {
                iconPath += "GarbageManagement.png";
            }
            else if (condition == 8)
            {
                iconPath += "EnergyConsumption.png";
            }
            else if (condition == 9)
            {
                iconPath += "Enviroment.png";
            }
            Icon.Image = UIImage.FromFile(iconPath);

            Title.Text = thisTip.TipName;
            Description.Text = thisTip.TipDescription;
        }

        partial void done(NSObject sender)
        {
            controller.DismissModalViewController(true);
        }

    }
}