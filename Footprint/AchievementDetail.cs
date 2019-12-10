using Foundation;
using System;
using UIKit;

namespace Footprint
{
    public partial class AchievementDetail : UIViewController
    {
        
        public AchievementManager.AchievementConfig achievement;
        AchievementManager.AchievementConfig original;

        public AchievementDetail (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            original = achievement;
            if(AchievementManager.getConfig(achievement.AchievementID) != null)
            {
                achievement = AchievementManager.getConfig(achievement.AchievementID);
            }
            MainLabel.Text = achievement.AchievementName;
            Description.Text = achievement.AchievementDescription;
            TopBar.Title = achievement.AchievementName;
            
            AchievementPreview.Image = UIImage.FromFile("Image/Achievements/" + achievement.ImageName);

            if (!achievement.Unlocked)
            {
                AchievementPreview.Image = UIImage.FromFile("Image/Achievements/" + "null.png");
                System.Diagnostics.Debug.WriteLine("Locked");

                if (achievement.achievementType == AchievementManager.AchievementConfig.AchievementType.ChallengeCount)
                {
                    System.Diagnostics.Debug.WriteLine("challengeType");
                    if (achievement.ChallengeCount < 1)
                    {
                        System.Diagnostics.Debug.WriteLine("zeroed");
                        ProgressBar.Progress = 0;
                    }
                    else
                    {
                        float percentage = (float)achievement.ChallengeCount / (float)original.ChallengeCount;
                        ProgressBar.Progress = 1.0f - percentage;
                    }
                }
                else
                {
                    float percentage = (float)achievement.challengNames.Count / (float)original.challengNames.Count;
                    ProgressBar.Progress = 1.0f - percentage;
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("unlocked");
                ProgressBar.Progress = 1.0f;
            }
        }


    }
}