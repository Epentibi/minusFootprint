using System;
using Foundation;
using UIKit;

namespace Footprint
{
    public static class imageManager
    {
        public static UIImage iconOfIndex(int condition)
        {
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
            return UIImage.FromFile(iconPath);
        }

    }
}
