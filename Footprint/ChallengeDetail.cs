using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class ChallengeDetail : UIViewController
    {
        public Challenges.Challenge challenge;
        public ChallengePage pg;

        public bool popView;
        bool challengeExists;

        public ChallengeDetail (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            if(!popView)
            {
                NavigationItem.LeftBarButtonItem = null;
            }
            else if(Filewrite.LoadChallenge().Contains(challenge.ChallengeID))
            {
                //if the thing exists
                AddButton.UserInteractionEnabled = false;
                AddButton.BackgroundColor = UIColor.Clear;
                AddButton.SetTitleColor(UIColor.LabelColor, UIControlState.Normal);
                AddButton.SetTitle(NSBundle.MainBundle.GetLocalizedString("Challenge already added"), UIControlState.Normal);
                AddButton.TitleLabel.Font = UIFont.SystemFontOfSize(18);
                AddButton.TitleLabel.AdjustsFontSizeToFitWidth = true;
                challengeExists = true;
            }

            TopLabel.Title = challenge.ChallengeName;
            Description.Text = challenge.ChallengeDescription;
            ConditionLabel.Text = challenge.Condition;
            TypeLabel.Text = NSBundle.MainBundle.GetLocalizedString(challenge.challengeType.ToString()) + NSBundle.MainBundle.GetLocalizedString(" Challenge");

            ConditionIcon.Image = UIImage.FromFile("Image/Challenge/Condition.png");


            int condition = challenge.ConditionValue;


            Icon.Image = imageManager.iconOfIndex(condition);


            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            var g = new System.Random(appDelegate.mainSeed + challenge.ChallengeID.GetHashCode());

            ChallengeArt.Image = UIImage.FromFile("Image/ChallengeTopic/" + challenge.ConditionValue.ToString() + "/" + g.Next(0, 6).ToString() + ".jpg");


            if (challenge.challengeType == Challenges.Challenge.ChallengeType.Daily)
            {
                TypeIcon.Image = UIImage.FromFile("Image/Challenge/Daily.png");
            }
            else if (challenge.challengeType == Challenges.Challenge.ChallengeType.ForceDaily)
            {
                TypeIcon.Image = UIImage.FromFile("Image/Challenge/ForceDaily.png");
            }
            else if (challenge.challengeType == Challenges.Challenge.ChallengeType.OneTime)
            {
                TypeIcon.Image = UIImage.FromFile("Image/Challenge/OneTime.png");
            }


        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        partial void AddButton_TouchUpInside(UIButton sender)
        {
            if (!challengeExists)
            {
                SQLConnector.SaveChallenge(challenge.ChallengeID);

                Filewrite.AddChallenge(challenge.ChallengeID);
                Challenges.SaveChallenge(challenge);
                if(challenge.challengeType == Challenges.Challenge.ChallengeType.ForceDaily)
                {
                    Filewrite.CreationDay(challenge.ChallengeID);
                }
            }

            if(!popView)
            {
                pg.ViewDidLoad();
                NavigationController.PopViewController(true);
            }
            else
            {
                NavigationController.DismissModalViewController(true);
            }
        }

        partial void cancelView(NSObject sender)
        {
            NavigationController.DismissModalViewController(true);
        }


    }
}
