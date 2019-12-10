using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverChallengeModule : DiscoverModule
    {

        public DiscoverChallengeModule(List<Challenges.Challenge> getChallenge)
        {
            challenges = getChallenge;
        }

        public List<Challenges.Challenge> challenges = new List<Challenges.Challenge>();

        public override string getDescription(NSIndexPath indexPath)
        {
            return challenges[indexPath.Row].Condition;
        }
        
        public override UIImage getImage(NSIndexPath indexPath)
        {
            return imageManager.iconOfIndex(challenges[indexPath.Row].ConditionValue);
        }

        public override string getName(NSIndexPath indexPath)
        {
            return challenges[indexPath.Row].ChallengeName;
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            return challenges[indexPath.Row].ConditionValue;
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            string challengeID = challenges[indexPath.Row].ChallengeID;
            System.Diagnostics.Debug.WriteLine("Selected item " + challenges[indexPath.Row].ChallengeName + ", status of item on whether added is " + Filewrite.LoadChallenge().Contains(challengeID));

            ChallengeDetail Cpage = mainController.Storyboard.InstantiateViewController("ChallengeDetail") as ChallengeDetail;
            var CpageNavigation = new UINavigationController(Cpage);
            Cpage.challenge = challenges[indexPath.Row];
            Cpage.popView = true;
            mainController.PresentModalViewController(CpageNavigation, true);
        }

        public override int getRowCount()
        {
            return challenges.Count;
        }
    }
}
