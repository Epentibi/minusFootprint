using System;
using System.Collections.Generic;
using Footprint.Base.lproj;
using Foundation;

namespace Footprint
{
    public static class DiscoveryCentral
    {

        public static DiscoverModule GetModule(int index, Discover discover)
        {
            if(index == 0)//Top Picks, requires SQL servers
            {
                var module = new DiscoverTopPickModule();
                return module;
            }
            if (index == 1)//Browse Link
            {
                var module = new DiscoverBrowseModule();
                module.Header = NSBundle.MainBundle.GetLocalizedString("Browse All");
                return module;
            }
            if (index == 2)
            {
                var module = new DiscoverRecommendationModule();
                return module;
            }
            if (index == 3)//Editor Pick, static link from BOD servers
            {
                var module = new DiscoverEditorPickModule();
                return module;
            }
            if (index == 4)
            {
                var module = new DiscoverSuggestTipModule();
                return module;
            }

            if (index > 4 && index < 8)
            {
                var topicRandom = new System.Random();
                int topicIndex = topicRandom.Next(0, 10); 
                while(discover.topics.Contains(topicIndex) || topicIndex == 2)
                {
                    topicIndex = topicRandom.Next(0, 10);
                }
                discover.topics.Add(topicIndex);

                var topicChallenges = new List<Challenges.Challenge>();

                foreach (Challenges.Challenge challenge in Challenges.challengeList)
                {
                    if(challenge.ConditionValue == topicIndex)
                    {
                        topicChallenges.Add(challenge);
                    }
                }

                var challengeTopicModule = new DiscoverChallengeModule(topicChallenges);
                challengeTopicModule.Header = Challenges.getChallengeName(topicIndex);
                return challengeTopicModule;
            }

            if (index > 7 && index < 10)
            {
                var topicRandom = new System.Random();
                int topicIndex = topicRandom.Next(0, 10);
                while (discover.topics.Contains(topicIndex) || topicIndex == 2)
                {
                    topicIndex = topicRandom.Next(0, 10);
                }
                discover.topics.Add(topicIndex);

                var topicTips = new List<TipLibrary.Tip>();

                foreach (TipLibrary.Tip tip in TipLibrary.tips)
                {
                    if (tip.ConditionIndex == topicIndex)
                    {
                        topicTips.Add(tip);
                    }
                }

                var tipTopicModule = new DiscoverTipsModule(topicTips);
                tipTopicModule.Header = Challenges.getChallengeName(topicIndex) + NSBundle.MainBundle.GetLocalizedString(" Tips");
                return tipTopicModule;
            }



            var random = new System.Random();
            var challenges = new List<Challenges.Challenge>();

            for (int l = 0; l < 10; l++)
            {
                challenges.Add(Challenges.challengeList[random.Next(0, Challenges.challengeList.Count)]);
            }

            var exampleModule = new DiscoverChallengeModule(challenges);
            exampleModule.Header = "Main Header";
            return exampleModule;
        }


    }
}
