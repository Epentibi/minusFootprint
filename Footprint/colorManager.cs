using System;
using CoreAnimation;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Footprint
{
    public static class colorManager
    {
        public static CAGradientLayer gradientColor(int index, UIView view)
        {
            var layer = new CAGradientLayer();
            layer.Frame = view.Bounds;
            var computeColor = color(index);
            layer.Colors = new CGColor[] { lighten(computeColor).CGColor , computeColor.CGColor };
            layer.Locations = new NSNumber[] { 0, 0.6 };
            layer.StartPoint = new CGPoint(0f, 0f);
            layer.EndPoint = new CGPoint(1, 1);


            return layer;
        }

         public static UIColor darken(UIColor color)
        {
            var hsv = new UIColor(0,0,0,0);

            nfloat h, s, b, a = 0;

            color.GetHSBA(out h,out s,out b,out a);

            return UIColor.FromHSB(h, s, b - b * 0.5f);
        }

        public static UIColor lighten(UIColor color)
        {
            var hsv = new UIColor(0, 0, 0, 0);

            nfloat h, s, b, a = 0;

            color.GetHSBA(out h, out s, out b, out a);

            return UIColor.FromHSB(h, s, b + b * 0.15f);
        }

        public static UIColor alternativeTint(int condition)
        {
            UIColor chosenColor;
            if (condition == 0)
            {
                chosenColor = UIColor.FromRGB(255, 103, 94); //Red
            }
            else if (condition == 1)
            {
                chosenColor = UIColor.FromRGB(252, 169, 53);//Organge
            }
            else if (condition == 2)
            {
                chosenColor = UIColor.FromRGB(255, 126, 109);//Yellow
            }
            else if (condition == 3)
            {
                chosenColor = UIColor.FromRGB(67, 154, 248);//Dark Blue
            }
            else if (condition == 4)
            {
                chosenColor = UIColor.FromRGB(118, 116, 238);//Purple
            }
            else if (condition == 5)
            {
                chosenColor = UIColor.FromRGB(159, 224, 251);//teal blue
            }
            else if (condition == 6)
            {
                chosenColor = UIColor.FromRGB(199, 199, 204);//grey
            }
            else if (condition == 7)
            {
                chosenColor = UIColor.FromRGB(216, 142, 109);//brown
            }
            else if (condition == 8)
            {
                chosenColor = UIColor.FromRGB(246, 88, 116);//pink
            }
            else if (condition == 9)
            {
                chosenColor = UIColor.FromRGB(70, 225, 109);//green
            }
            else
            {
                chosenColor = UIColor.White;
            }

            return chosenColor;
        }

        public static UIColor color(int condition)
        {
            UIColor chosenColor;
            if (condition == 0)
            {
                chosenColor = UIColor.FromRGB(255, 59, 48); //Red
            }
            else if (condition == 1)
            {
                chosenColor = UIColor.FromRGB(255, 149, 0);//Organge
            }
            else if (condition == 2)
            {
                chosenColor = UIColor.FromRGB(255, 204, 0);//Yellow
            }
            else if (condition == 3)
            {
                chosenColor = UIColor.FromRGB(0, 122, 255);//Dark Blue
            }
            else if (condition == 4)
            {
                chosenColor = UIColor.FromRGB(88, 86, 214);//Purple
            }
            else if (condition == 5)
            {
                chosenColor = UIColor.FromRGB(100, 210, 255);//teal blue
            }
            else if (condition == 6)
            {
                chosenColor = UIColor.FromRGB(174, 174, 178);//grey
            }
            else if (condition == 7)
            {
                chosenColor = UIColor.FromRGB(180, 112, 82);//green-yellow
            }
            else if (condition == 8)
            {
                chosenColor = UIColor.FromRGB(255, 45, 85);//pink
            }
            else if (condition == 9)
            {
                chosenColor = UIColor.FromRGB(48, 209, 88);//green
            }
            else
            {
                chosenColor = UIColor.White;
            }

            return chosenColor;
        }

    }
}
