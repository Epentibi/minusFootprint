using System;

using Foundation;
using UIKit;

namespace Footprint
{
    public partial class JustCell : UITableViewCell
    {
        public JustCell(IntPtr handle) : base(handle)
        {
             
        }

        public void UpdateCell(string name, UIImage image)
        {
            Image.Image = image;
            Label.Text = name;
            //SelectionStyle = UITableViewCellSelectionStyle.None;
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
