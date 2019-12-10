using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class CustomCell : UITableViewCell
    {
        public CustomCell (IntPtr handle) : base (handle)
        {
            ContentView.BackgroundColor = UIColor.FromRGB(218, 255, 127);
        }
        public void UpdateCell(string name, UIImage image, string description)
        {
            mainlabel.Text = name;
            mainicon.Image = image;
            secondaryLabel.Text = description;
            mainlabel.AdjustsFontSizeToFitWidth = true;
        }

        public void UpdateColor(UIColor color)
        {
            ContentView.BackgroundColor = color;
        }
    }
}