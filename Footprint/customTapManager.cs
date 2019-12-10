using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace Footprint
{

    public class customTapManager : UITapGestureRecognizer
    {
        public customTapManager(UIView v)
        {
            view = v;
            NumberOfTapsRequired = 1;
        }

        public UIView view;

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            UIView.Animate(
            duration: 0.12f,
            delay: 0,
            options: UIViewAnimationOptions.CurveLinear,
            animation: () => {
                view.Transform = CGAffineTransform.MakeScale(0.97f, 0.97f);
            },
            completion: () => {
                view.Transform = CGAffineTransform.MakeScale(0.97f, 0.97f);
            }
            );
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            System.Diagnostics.Debug.WriteLine("good");

            if(view is DiscoverCell)
            {
                var d = (DiscoverCell)view;
                d.featureModule.OnSelected(d.thisPath);
            }
            else if(view is SmallDiscoverCell)
            {
                var d = (SmallDiscoverCell)view;
                d.DiscoverModule.itemSelected(d.indexpath);
            }

            cancelAnimation();

            
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);

            cancelAnimation();
        }

        public override void Reset()
        {
            cancelAnimation();
        }

        void cancelAnimation()
        {
            view.Layer.RemoveAllAnimations();

            System.Diagnostics.Debug.WriteLine("ended");
            UIView.Animate(
            duration: 0.12f,
            delay: 0,
            options: UIViewAnimationOptions.CurveLinear,
            animation: () => {
                view.Transform = CGAffineTransform.MakeScale(1f, 1f);
            },
            completion: () => {
                view.Transform = CGAffineTransform.MakeScale(1f, 1f);
            }
            );
        }
    }
}
