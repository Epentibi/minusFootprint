using Foundation;
using System;
using UIKit;
using Footprint.Base.lproj;

namespace Footprint
{
    public partial class DailyChallenge : UIViewController
    {
        public Challenges.Challenge challenge;
        public Daily day;
        public HubDaily hub;

        public UIViewController controller;

        public bool PopView;
        

        public DailyChallenge(IntPtr handle) : base(handle)
        {

        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //showAchievementPage();

            TopBar.Title = challenge.ChallengeName;
            Description.Text = challenge.ChallengeDescription;
            TypeLabel.Text = NSBundle.MainBundle.GetLocalizedString(challenge.challengeType.ToString()) + NSBundle.MainBundle.GetLocalizedString(" Challenge");

            ConditionIcon.Image = UIImage.FromFile("Image/Challenge/Condition.png");

            string iconPath = "Image/Challenge/";

            int condition = challenge.ConditionValue;

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

            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

            var g = new System.Random(appDelegate.mainSeed + challenge.ChallengeID.GetHashCode());

            ChallengeArt.Image = UIImage.FromFile("Image/ChallengeTopic/" + challenge.ConditionValue.ToString() + "/" + g.Next(0,6).ToString() + ".jpg");

            if (challenge.challengeType != Challenges.Challenge.ChallengeType.OneTime)
            {
                ConditionLabel.Text = challenge.RequiredDays.ToString() + NSBundle.MainBundle.GetLocalizedString(" days left to go");

                if (!Filewrite.NotDone(challenge.ChallengeID))
                {
                    TickButton.Hidden = true;
                }
            }
            else
            {
                ConditionLabel.Text = challenge.Condition;
                TickButton.SetTitle(NSBundle.MainBundle.GetLocalizedString("COMPLETE"), UIControlState.Normal);
            }

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

        public void showAchievementPage()
        {
            //this.View.Add(AchievementView);
            var achievementView = new UIView();
            View.AddSubview(achievementView);
            achievementView.BackgroundColor = UIColor.Yellow;
            View.AddConstraint(NSLayoutConstraint.Create(achievementView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading, 1.0f, 32.0f));
            View.AddConstraint(NSLayoutConstraint.Create(achievementView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, View, NSLayoutAttribute.Trailing, 1.0f, -32.0f));
            View.AddConstraint(NSLayoutConstraint.Create(achievementView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1.0f, -128.0f));
            View.AddConstraint(NSLayoutConstraint.Create(achievementView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1.0f, 128.0f));
        }

        public void CompleteChallenge()
        {
            if (!PopView)
            {
                if (Filewrite.LoadChallenge() == null)
                {
                    hub.addPad();
                }
                else if (Filewrite.LoadChallenge().Count < 1)
                {
                    hub.addPad();
                }
            }

            Filewrite.CompleteChallenge();
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
            appDelegate.shouldUpdateView = true;

            ChallengeComplete f = this.Storyboard.InstantiateViewController("CompleteChallenge") as ChallengeComplete;
            f.image = ChallengeArt.Image;
            f.challenge = challenge;
            f.ChallengeController = this.NavigationController;

            //do if for debug v
            //appDelegate.toUnlock = AchievementManager.achievements[0];

            if (appDelegate.toUnlock != null)
            {
                AchievementUnlock unlockPage = this.Storyboard.InstantiateViewController("AchievementUnlock") as AchievementUnlock;
                controller = f;
                unlockPage.controller = this;
                unlockPage.unlockedAchievement = appDelegate.toUnlock;
                this.NavigationController.PresentViewController(unlockPage, true, null);
                appDelegate.toUnlock = null;
            }
            else
            {
                this.NavigationController.PresentModalViewController(f, true);
            }
        }

        partial void TickButton_TouchUpInside(UIButton sender)
        {
            if (challenge.challengeType != Challenges.Challenge.ChallengeType.OneTime)
            {
                if (challenge.RequiredDays > 1)
                {
                    challenge.RequiredDays -= 1;
                    Challenges.SaveChallenge(challenge);
                    Filewrite.SaveDay(challenge.ChallengeID);
                    //TickButton.Hidden = true;
                    ConditionLabel.Text = challenge.RequiredDays.ToString() + NSBundle.MainBundle.GetLocalizedString(" days left to go");

                    if (!PopView)
                    {
                        hub.UpdateChallenge(challenge.ChallengeID, challenge.RequiredDays);
                    }

                    UIView.Animate(duration: 0.5f, delay: 0, options: UIViewAnimationOptions.CurveEaseIn, animation: () =>
                    {
                        TickButton.BackgroundColor = UIColor.White;
                    },

                    completion: () =>
                    {
                        TickButton.BackgroundColor = UIColor.White;
                        TickButton.Hidden = true;
                    });
                }
                else
                {
                    Filewrite.RemoveChallenge(challenge.ChallengeID);
                    if (!PopView)
                    {
                        hub.RemoveChallenge(challenge.ChallengeID);
                    }
                    AchievementManager.PassNewChallenge(challenge, UIApplication.SharedApplication.Delegate as AppDelegate);
                    //NavigationController.PopViewController(true);
                    CompleteChallenge();
                }
            }
            else
            {
                Filewrite.RemoveChallenge(challenge.ChallengeID);
                if (!PopView)
                {
                    hub.RemoveChallenge(challenge.ChallengeID);
                }
                AchievementManager.PassNewChallenge(challenge, UIApplication.SharedApplication.Delegate as AppDelegate);
                //NavigationController.PopViewController(true);

                UIView.Animate(duration: 0.5f, delay: 0, options: UIViewAnimationOptions.CurveEaseIn, animation: () =>
                {
                    TickButton.BackgroundColor = UIColor.White;
                },

                completion: () =>
                {
                    TickButton.BackgroundColor = UIColor.White;
                    TickButton.Hidden = true;
                });
                CompleteChallenge();
            }

            
        }

        partial void Done(NSObject sender)
        {
            this.DismissModalViewController(true);
        }
    }
}