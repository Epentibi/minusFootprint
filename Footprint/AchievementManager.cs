using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Footprint
{
    public static class AchievementManager
    {
        [Serializable]
        public class AchievementConfig
        {
            public string AchievementName;
            public string AchievementID;
            public string AchievementDescription;
            public enum AchievementType { ChallengeCount, Challenges}
            public AchievementType achievementType;
            public string ImageName;

            public int ChallengeCount;


            //the type of challenge, etc foot source
            public bool CountType;
            public int ChallengeIndex;

            public List<string> challengNames = new List<string>();
            public bool Unlocked;
        }

        public static List<AchievementConfig> achievements = ExcelReaderTest.ReadAchievementExcel();
         /*
        public static List<AchievementConfig> achievements = new List<AchievementConfig>()
        {
            new AchievementConfig()
            {
                AchievementName = "1st Challenge",
                AchievementDescription = "Complete One Challenge",
                achievementType = AchievementConfig.AchievementType.ChallengeCount,
                ChallengeCount = 1
            }
        };*/

        public static AchievementConfig getConfig(string name)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(documents + "/achievement"))
            {
                Directory.CreateDirectory(documents + "/achievement");
            }
            if (File.Exists(documents + "/achievement/" + name))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/achievement/" + name);
                var data = (AchievementConfig)bf.Deserialize(f);
                f.Close();
                return data;
            }
            else
            {
                return null;
            }
        }

        public static AchievementConfig nextAchievement()
        {
            var dict = new Dictionary<string, int>();
            foreach(AchievementConfig d in achievements)
            {
                if(d.achievementType == AchievementConfig.AchievementType.ChallengeCount)
                {
                     if(!getConfig(d.AchievementID).Unlocked)
                    {
                        dict.Add(d.AchievementID, getConfig(d.AchievementID).ChallengeCount);
                    }
                }
            }
            dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            if(dict.Count < 1)
            {
                return null;
            }
            return getConfig(dict.Keys.First());
        }

        public static void PassNewChallenge(Challenges.Challenge ChallengeName, AppDelegate appDelegate)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(documents + "/achievement"))
            {
                Directory.CreateDirectory(documents + "/achievement");
            }
            foreach(AchievementConfig achievement in achievements)
            {
                AchievementConfig data = achievement;

                if (File.Exists(documents + "/achievement/" + achievement.AchievementID))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream f = File.OpenRead(documents + "/achievement/" + achievement.AchievementID);
                    data = (AchievementConfig)bf.Deserialize(f);
                    f.Close();
                }
                if (data.Unlocked != true)
                {
                    FileStream file = File.Create(documents + "/achievement/" + achievement.AchievementID);

                    BinaryFormatter b1f = new BinaryFormatter();

                    if (achievement.achievementType == AchievementConfig.AchievementType.ChallengeCount)
                    {
                        if (achievement.CountType)
                        {
                            if (ChallengeName.ConditionValue == achievement.ChallengeIndex)
                            {
                                data.ChallengeCount -= 1;
                            }
                        }
                        else
                        {
                            data.ChallengeCount -= 1;
                        }
                        if (data.ChallengeCount <= 0)
                        {
                            data.Unlocked = true;
                            System.Diagnostics.Debug.WriteLine("dataname = " + data.AchievementName);
                            appDelegate.toUnlock = data;
                        }
                    }
                    else
                    {
                        if (data.challengNames.Contains(ChallengeName.ChallengeID))
                        {
                            data.challengNames.Remove(ChallengeName.ChallengeID);
                        }
                        if (data.challengNames.Count <= 0)
                        {
                            data.Unlocked = true;
                        }
                    }
                    b1f.Serialize(file, data);
                    file.Close();
                }
            }
        }
    }
}
