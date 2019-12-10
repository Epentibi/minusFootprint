using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using Foundation;

namespace Footprint
{
    public static class Challenges
    {
        [Serializable]
        public class Challenge
        {
            public string ChallengeName;
            public string ChallengeID;
            public enum ChallengeType { OneTime, Daily, ForceDaily }
            public ChallengeType challengeType;
            public string ChallengeDescription;
            public string Condition;
            public string languageCode;

            public int ConditionValue;//Means the survey it refers to, same index as the surveyselection
            public int[] ConditionIndex;//The index saved
            public int[] AdditionalIndex;//Additional index for the transportation

            //ForceDaily
            public bool BonusChance;
            public string BonusChanceTip;

            //Daily for both
            public int RequiredDays;
            public string[] ReminderMessages;
        }

        public static List<Challenge> challengeList = ExcelReaderTest.ReadExcel();

        /*
       public static List<Challenge> challengeList = new List<Challenge>()
       {
           new Challenge()
           {
               ChallengeName = "Metro-Man",
               challengeType = Challenge.ChallengeType.Daily,
               ChallengeDescription = "Take Metro when you could take other forms of transportation, if you've done this one day, tick the day! Take metro for 20 days to complete this challenge",
               Condition = "Take metro for 20 days",
               ConditionValue = 3,
               ConditionIndex = new int[] {2},
               RequiredDays = 20,
               ReminderMessages = new string[] {"Try to take metro today :)", "Metro is eco-friendly, try to use it!"}
           },
           new Challenge()
           {
               ChallengeName = "中国人",
               challengeType = Challenge.ChallengeType.Daily,
               ChallengeDescription = "Whether it is lunch, dinner, breakfast or a little snack, try not to waste any. If you did not waste any for a day, tick the day! Try not to waste food for 20 days to complete this challenge!",
               Condition = "Don't waste food for 20 days",
               ConditionValue = 2,
               ConditionIndex = new int[] {1,2,3,4 },
               RequiredDays = 20,
               ReminderMessages = new string[] {"Remember not to waste food :D","Try to take what you can finish eating!" }
           },
           new Challenge()
           {
               ChallengeName = "Saving Week",
               challengeType = Challenge.ChallengeType.ForceDaily,
               ChallengeDescription = "Saving Week! Keep your daily food cost below 400¥ for one week to complete this challenge :D",
               Condition = "Keep daily food cost below 400¥ for one week",
               ConditionValue = 1,
               ConditionIndex = new int[] {3, 4},
               RequiredDays = 7,
               ReminderMessages = new string[] {"Remember to keep your daily food cost below 400¥!" }
           },
           new Challenge()
           {
               ChallengeName = "All Aboard!",
               challengeType = Challenge.ChallengeType.OneTime,
               ChallengeDescription = "Need to go somewhere? Take a train! Modern trains are extremely fast and affordable, also it uses renewable energy instead of coal!",
               Condition = "Take a train for once",
               ConditionValue = 4,
               ConditionIndex = new int[] {1,2}
           },
           new Challenge()
           {
               ChallengeName = "Meatless Morning",
               challengeType = Challenge.ChallengeType.ForceDaily,
               ChallengeDescription = "For one week, don't eat any meat for your breakfast to complete this challenge.",
               Condition = "Don't eat meat at breakfast for one week",
               ConditionValue = 0,
               ConditionIndex = new int[] {0,1},
               RequiredDays = 7,
               ReminderMessages = new string[] {"Remember not to eat meat for your breakfast!"}
           },
           new Challenge()
           {
               ChallengeName = "Walk Walk Walk",
               challengeType = Challenge.ChallengeType.Daily,
               ChallengeDescription = "Walk for short distance travels for 10 days to complete this challenge",
               Condition = "Walk for short distance travels for 10 days",
               ConditionValue = 3,
               ConditionIndex = new int[] {1,2},
               RequiredDays = 10,
               ReminderMessages = new string[] {"Remember to walk for short distance travels today!"}
           }
       };*/

        public static List<Challenge> getChallengesbyIndex(int index)
        {
            var list = new List<Challenge>();
            foreach(Challenge d in challengeList)
            {
                if(d.ConditionValue == index)
                {
                    list.Add(d);
                }
            }
            return list;
        }

        public static void SaveChallenge(Challenge challenge)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(documents + "/ChallengeSaves"))
            {
                Directory.CreateDirectory(documents + "/ChallengeSaves");
            }

            FileStream file = File.Create(documents + "/ChallengeSaves/"+challenge.ChallengeID);
            BinaryFormatter b1f = new BinaryFormatter();
            challenge.languageCode = NSBundle.MainBundle.PreferredLocalizations[0];
            b1f.Serialize(file, challenge);
            file.Close();
        }

        public static Challenge getChallengeByID(string ID)
        {
            foreach(Challenge challenge in challengeList)
            {
                if(challenge.ChallengeID == ID)
                {
                    return challenge;
                }
            }
            return null;
        }
         
        public static Challenge LoadChallenge(string ID)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/ChallengeSaves/" + ID))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/ChallengeSaves/" + ID);

                Challenge data = (Challenge)bf.Deserialize(file);
                file.Close();
                if(data.languageCode != NSBundle.MainBundle.PreferredLocalizations[0])
                {
                    foreach(Challenge d in challengeList)
                    {
                        if(d.ChallengeID == ID)
                        {
                            data.ChallengeName = d.ChallengeName;
                            data.ChallengeDescription = d.ChallengeDescription;
                            data.Condition = d.Condition;
                            data.ReminderMessages = d.ReminderMessages;
                        }
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
        }

        public static List<Challenge> shuffleChallengeList(List<Challenge> challenges)
        {
            var challenge = challenges;
            challenge.ShuffleMe();
            return challenge;
        }

        public static string getChallengeName(int index)
        {
            switch (index)
            {
                case 0:
                    return NSBundle.MainBundle.GetLocalizedString("Meat Consumption");
                case 1:
                    return NSBundle.MainBundle.GetLocalizedString("Food Waste");
                case 2:
                    return NSBundle.MainBundle.GetLocalizedString("Food Cost");
                case 3:
                    return NSBundle.MainBundle.GetLocalizedString("Daily Transport");
                case 4:
                    return NSBundle.MainBundle.GetLocalizedString("Long-Dist Transport");
                case 5:
                    return NSBundle.MainBundle.GetLocalizedString("Paper Usage");
                case 6:
                    return NSBundle.MainBundle.GetLocalizedString("Plastic Usage");
                case 7:
                    return NSBundle.MainBundle.GetLocalizedString("Garbage Management");
                case 8:
                    return NSBundle.MainBundle.GetLocalizedString("Power Consumption");
                case 9:
                    return NSBundle.MainBundle.GetLocalizedString("General Environment");
                default:
                    return "test";
            }
        }
    }
}
