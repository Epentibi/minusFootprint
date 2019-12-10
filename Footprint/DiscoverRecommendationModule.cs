using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverRecommendationModule : DiscoverModule
    {

        public List<Challenges.Challenge> recommendedChallenge = new List<Challenges.Challenge>();
        bool noRecommendations;


        public DiscoverRecommendationModule()
        {
            Header = NSBundle.MainBundle.GetLocalizedString("Recommended for You");
            secondaryHeader = NSBundle.MainBundle.GetLocalizedString("Selection of challenges based on survey results");

            var randomizer = new System.Random();
            var surveyResults = Filewrite.getSurveyResults();
            var challengeValues = new Dictionary<int, int>();
            foreach (KeyValuePair<string, int> result in surveyResults)
            {
                int isIndex = 0;
                if (Int32.TryParse(result.Key, out isIndex))
                {
                    challengeValues.Add(isIndex, result.Value);
                }
            }


            System.Diagnostics.Debug.WriteLine("number is " + challengeValues.Count);

            challengeValues = challengeValues.OrderByDescending(key => key.Value).ToDictionary(kv => kv.Key, kv => kv.Value);

            while (recommendedChallenge.Count < 15 && challengeValues.Count > 0)
            {
                int i = 0;
                if (challengeValues.ElementAt(0).Value > 8)
                {
                    i = randomizer.Next(3, 4);
                }
                else if (challengeValues.ElementAt(0).Value > 6)
                {
                    i = randomizer.Next(2, 3);
                }
                else if (challengeValues.ElementAt(0).Value > 5)
                {
                    i = randomizer.Next(1, 3);
                }
                else if (challengeValues.ElementAt(0).Value > 4)
                {
                    i = randomizer.Next(1, 2);
                }
                else
                {
                    i = randomizer.Next(0, 2);
                }
                var list = Challenges.getChallengesbyIndex(challengeValues.ElementAt(0).Key);
                int count = list.Count;
                if(i > count)
                {
                    i = count;
                }

                while (i > 0)
                {
                    var thisChallenge = list[randomizer.Next(0, count)];
                    while(recommendedChallenge.Contains(thisChallenge))
                    {
                        thisChallenge = list[randomizer.Next(0, count)];
                    }
                    recommendedChallenge.Add(thisChallenge);
                    i -= 1;
                }

                challengeValues.Remove(challengeValues.ElementAt(0).Key);
            }

            if(recommendedChallenge.Count < 1)
            {
                noRecommendations = true;
            }

            ShuffleMe(recommendedChallenge);
        }


        public override bool addButtomVisibility()
        {
            if (noRecommendations)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShuffleMe<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            
            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }

        public override bool secondaryHeaderVisibility()
        {
            return true;
        }

        public override int getRowCount()
        {
            if (recommendedChallenge.Count > 0)
            {
                return recommendedChallenge.Count;
            }
            else
            {
                return 1;
            }
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return 3;
            }
            else
            {
                return recommendedChallenge[indexPath.Row].ConditionValue;
            }
        }

        public override UIImage getImage(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return UIImage.FromFile("Image/Discover/Info.png");
            }
            else
            {
                return imageManager.iconOfIndex(recommendedChallenge[indexPath.Row].ConditionValue);
            }
        }

        public override string getName(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return NSBundle.MainBundle.GetLocalizedString("No Surveys Done");
            }
            else
            {
                return recommendedChallenge[indexPath.Row].ChallengeName;
            }
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            if(noRecommendations)
            {
                return;
            }

            string challengeID = recommendedChallenge[indexPath.Row].ChallengeID;
            System.Diagnostics.Debug.WriteLine("Selected item " + recommendedChallenge[indexPath.Row].ChallengeName + ", status of item on whether added is " + Filewrite.LoadChallenge().Contains(challengeID));

            ChallengeDetail Cpage = mainController.Storyboard.InstantiateViewController("ChallengeDetail") as ChallengeDetail;
            var CpageNavigation = new UINavigationController(Cpage);
            Cpage.challenge = recommendedChallenge[indexPath.Row];
            Cpage.popView = true;
            mainController.PresentModalViewController(CpageNavigation, true);
        }

    }
}