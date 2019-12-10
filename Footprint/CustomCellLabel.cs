using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class CustomCellLabel : UITableViewCell
    {
        public CustomCellLabel (IntPtr handle) : base (handle)
        {

        }

        public void UpdateCell(string name, UIImage image)
        {
            mainlabel.Text = name;
            mainicon.Image = image;
            mainlabel.AdjustsFontSizeToFitWidth = true;
        }

        public void SetImage()
        {

        }

        public void UpdateColor(UIColor color)
        {
            ContentView.BackgroundColor = color;
        }

    }
}