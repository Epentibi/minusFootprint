using System;
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

namespace Footprint
{
    public class SmallDiscoverCell : UICollectionViewCell
    {
        [Export("initWithFrame:")]
        public SmallDiscoverCell(CGRect frame) : base(frame)
        {

        }
        public DiscoverModule DiscoverModule;
        public NSIndexPath indexpath;


        public void Initialize(DiscoverModule module, NSIndexPath indexPath)
        {
            DiscoverModule = module;
            indexpath = indexPath;

            this.Layer.AddSublayer(colorManager.gradientColor(module.getColorCode(indexPath), this));
            this.Layer.CornerRadius = 16;
            this.ClipsToBounds = true;

            UIImageView icon = new UIImageView();
            icon.TranslatesAutoresizingMaskIntoConstraints = false;
            this.AddSubview(icon);
            icon.Image = module.getImage(indexPath);
            this.AddConstraint(NSLayoutConstraint.Create(icon, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 36.0f));
            this.AddConstraint(NSLayoutConstraint.Create(icon, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 36.0f));
            this.AddConstraint(NSLayoutConstraint.Create(icon, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1.0f, 16.0f));
            this.AddConstraint(NSLayoutConstraint.Create(icon, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1.0f, 16.0f));

            UILabel label = new UILabel
            {
                Text = module.getName(indexPath),
                Font = UIFont.BoldSystemFontOfSize(24),
                TextColor = UIColor.White,
                AdjustsFontSizeToFitWidth = true
            };
            label.TranslatesAutoresizingMaskIntoConstraints = false;
            this.AddSubview(label);
            this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1.0f, 16.0f));
            this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1.0f, -16.0f));
            this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Top, NSLayoutRelation.Equal, icon, NSLayoutAttribute.Bottom, 1.0f, 8.0f));
            this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 42.0f));

            if (module.addButtomVisibility())
            {
                UIButton addButtom = new UIButton(UIButtonType.ContactAdd)
                {
                    TintColor = UIColor.White
                };
                addButtom.TranslatesAutoresizingMaskIntoConstraints = false;
                this.AddSubview(addButtom);
                this.AddConstraint(NSLayoutConstraint.Create(addButtom, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 24.0f));
                this.AddConstraint(NSLayoutConstraint.Create(addButtom, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 24.0f));
                this.AddConstraint(NSLayoutConstraint.Create(addButtom, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1.0f, -16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(addButtom, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1.0f, 16.0f));
            }

            this.AddGestureRecognizer(new customTapManager(this));
        }
    }
}
