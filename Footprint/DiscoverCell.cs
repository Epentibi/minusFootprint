using System;
using UIKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;

namespace Footprint
{
    public class DiscoverCell : UICollectionViewCell
    {
        public FeatureModule featureModule;
        public NSIndexPath thisPath;

        [Export("initWithFrame:")]
        public DiscoverCell(CGRect frame) : base(frame)
        {
            //sBackgroundView = new UIView { BackgroundColor = UIColor.Orange };

            //SelectedBackgroundView = new UIView { BackgroundColor = UIColor.Green };

            //ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
            //ContentView.Layer.BorderWidth = 2.0f;
            //ContentView.BackgroundColor = UIColor.Green;
        }

        public virtual void Initialize(FeatureModule module, NSIndexPath indexPath)
        {
            UserInteractionEnabled = true;

            /*
            var gradientLayer = new CAGradientLayer();

            gradientLayer.Colors = new[] { UIColor.Red.CGColor, UIColor.Blue.CGColor };
            gradientLayer.Locations = new NSNumber[] { 0, 1 };
            gradientLayer.Frame = this.Bounds;*/

            //this.BackgroundColor = UIColor.Clear;
            featureModule = module;
            thisPath = indexPath;

            System.Diagnostics.Debug.WriteLine("I exist");

            if (featureModule.getType(thisPath) == 0)
            {

                System.Diagnostics.Debug.WriteLine("it is one");
                
                UIImageView background = new UIImageView();
                background.Image = featureModule.image(thisPath);
                background.ClipsToBounds = true;
                background.Layer.CornerRadius = 16;
                this.AddSubview(background);

                //background.BackgroundColor = UIColor.Green;
                background.TranslatesAutoresizingMaskIntoConstraints = false;
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1.0f, 0));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1.0f, 0));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1.0f, 0));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1.0f, 0));

                UILabel label = new UILabel
                {
                    Text = module.Title(indexPath),
                    Font = UIFont.BoldSystemFontOfSize(36),
                    TextColor = UIColor.White,
                    AdjustsFontSizeToFitWidth = true,
                    TextAlignment = UITextAlignment.Center
                };
                label.TranslatesAutoresizingMaskIntoConstraints = false;
                this.AddSubview(label);
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1.0f, 16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1.0f, -16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1.0f, -16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 42.0f));
            }
            else if (featureModule.getType(thisPath) == 1)
            {
                this.Layer.AddSublayer(colorManager.gradientColor(module.getColorCode(indexPath), this));

                UILabel label = new UILabel
                {
                    Text = module.Title(indexPath),
                    Font = UIFont.BoldSystemFontOfSize(36),
                    TextColor = UIColor.White,
                    AdjustsFontSizeToFitWidth = true,
                    TextAlignment = UITextAlignment.Center
                };
                label.TranslatesAutoresizingMaskIntoConstraints = false;
                this.AddSubview(label);
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1.0f, 16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1.0f, -16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1.0f, -16.0f));
                this.AddConstraint(NSLayoutConstraint.Create(label, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 42.0f));

                UIImageView background = new UIImageView();
                background.Image = featureModule.image(thisPath);
                background.TranslatesAutoresizingMaskIntoConstraints = false;
                this.AddSubview(background);
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 84));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1.0f, 84));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1.0f, 0));
                this.AddConstraint(NSLayoutConstraint.Create(background, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, label, NSLayoutAttribute.Top, 1.0f, -6.0f));
            }
            else if (featureModule.getType(thisPath) == 2)
            {

            }

            this.Layer.CornerRadius = 16;
            this.ClipsToBounds = true;

            this.AddGestureRecognizer(new customTapManager(this));

        }
    }
    
}
