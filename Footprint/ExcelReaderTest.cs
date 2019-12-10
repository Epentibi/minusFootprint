using System.IO;
using System;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Reflection;
using Syncfusion.XlsIO;
using Foundation;

namespace Footprint
{
    public static class ExcelReaderTest
    {
        public static void readFile()
        {
            System.Diagnostics.Debug.WriteLine("QuickTest");
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("hi.txt"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(result);
            }

        }

        public static List<Challenges.Challenge> ReadExcel()
        {

             
            System.Diagnostics.Debug.WriteLine(NSBundle.MainBundle.PreferredLocalizations[0]);
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;


            IWorkbook workbook;

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var assembly = Assembly.GetExecutingAssembly();

            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("database.xlsx"));

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            workbook = application.Workbooks.Open(stream);

            int localizationIndex = 0;
            if(NSBundle.MainBundle.PreferredLocalizations[0] == "en")
            {
                localizationIndex = 0;
            }
            else if (NSBundle.MainBundle.PreferredLocalizations[0] == "zh-Hans")
            {
                localizationIndex = 1;
            }


            System.Diagnostics.Debug.WriteLine(workbook.Worksheets[localizationIndex].Rows[0].Cells[0].Value);
            var currentSheet = workbook.Worksheets[localizationIndex];
            var challengeList = new List<Challenges.Challenge>();
            int i = 0;
            int total = Int32.Parse(currentSheet.Columns[9].Cells[1].Value);
            while (i < total)
            {
                var newChallenge = new Challenges.Challenge();

                newChallenge.ChallengeName = currentSheet.Columns[0].Cells[i + 2].Value;
                newChallenge.ChallengeID = currentSheet.Columns[1].Cells[i + 2].Value;


                var challengeTypeRaw = currentSheet.Columns[2].Cells[i + 2].Value;

                if (challengeTypeRaw.ToLower().Contains("force"))
                {
                    newChallenge.challengeType = Challenges.Challenge.ChallengeType.ForceDaily;
                    int result = -5;
                    if (Int32.TryParse(currentSheet.Columns[6].Cells[i + 2].Value, out result))
                    {

                    }
                    newChallenge.RequiredDays = result;
                }
                else if (challengeTypeRaw.ToLower() == "daily")
                {
                    newChallenge.challengeType = Challenges.Challenge.ChallengeType.Daily;
                    int result = -5;
                    if(Int32.TryParse(currentSheet.Columns[6].Cells[i + 2].Value, out result))
                    {

                    }
                    newChallenge.RequiredDays = result;
                }
                else if (challengeTypeRaw.ToLower().Contains("one"))
                {
                    newChallenge.challengeType = Challenges.Challenge.ChallengeType.OneTime;
                }

                int challengeTopicIndex = 0;
                if (Int32.TryParse(currentSheet.Columns[3].Cells[i + 2].Value, out challengeTopicIndex))
                {

                }
                newChallenge.ConditionValue = challengeTopicIndex;


                newChallenge.ChallengeDescription = currentSheet.Columns[4].Cells[i + 2].Value;

                newChallenge.Condition = currentSheet.Columns[5].Cells[i + 2].Value;

                newChallenge.ReminderMessages = currentSheet.Columns[7].Cells[i + 2].Value.Split("; "); //works

                challengeList.Add(newChallenge);
                i++;
            }
            System.Diagnostics.Debug.WriteLine("I am fine");
            return challengeList;
            
        }

        public static List<AchievementManager.AchievementConfig> ReadAchievementExcel()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("achievements.xlsx"));

            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            IWorkbook workbook = application.Workbooks.Open(stream);

            int localizationIndex = 0;
           
            if (NSBundle.MainBundle.PreferredLocalizations[0] == "en")
            {
                localizationIndex = 0;
            }
            else if (NSBundle.MainBundle.PreferredLocalizations[0] == "zh-Hans")
            {
                localizationIndex = 1;
            }


            System.Diagnostics.Debug.WriteLine(workbook.Worksheets[localizationIndex].Rows[0].Cells[0].Value);

            var achievementList = new List<AchievementManager.AchievementConfig>();
            int i = 0;
            while (i < 4)
            {
                var newAchievement = new AchievementManager.AchievementConfig();
                newAchievement.AchievementName = workbook.Worksheets[localizationIndex].Columns[0].Cells[i + 2].Value;
                newAchievement.AchievementID = workbook.Worksheets[localizationIndex].Columns[1].Cells[i + 2].Value;
                newAchievement.AchievementDescription = workbook.Worksheets[localizationIndex].Columns[2].Cells[i + 2].Value;
                newAchievement.ImageName = workbook.Worksheets[localizationIndex].Columns[5].Cells[i + 2].Value;
                var TypeRaw = workbook.Worksheets[localizationIndex].Columns[3].Cells[i + 2].Value;
                if(TypeRaw.ToLower().Contains("count"))
                {
                    newAchievement.achievementType = AchievementManager.AchievementConfig.AchievementType.ChallengeCount;
                    int required = 999;
                    if (Int32.TryParse(workbook.Worksheets[localizationIndex].Columns[4].Cells[i + 2].Value, out required))
                    {

                    }
                    newAchievement.ChallengeCount = required;
                }
                else
                {
                    newAchievement.achievementType = AchievementManager.AchievementConfig.AchievementType.Challenges;
                }

                achievementList.Add(newAchievement);
                i++;
            }
            return achievementList;

        }

        public static List<TipLibrary.Tip> ReadTipsExcel()
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            IWorkbook workbook;


            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var assembly = Assembly.GetExecutingAssembly();

            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("tips.xlsx"));

            Stream stream = assembly.GetManifestResourceStream(resourceName);
            System.Diagnostics.Debug.WriteLine(resourceName);

            workbook = application.Workbooks.Open(stream);


            int localizationIndex = 0;

            if (NSBundle.MainBundle.PreferredLocalizations[0] == "en")
            {
                localizationIndex = 0;
            }
            else if (NSBundle.MainBundle.PreferredLocalizations[0] == "zh-Hans")
            {
                localizationIndex = 1;
                System.Diagnostics.Debug.WriteLine("chinese tip");
            }

            var newTipList = new List<TipLibrary.Tip>();

            int ind = 0;

            System.Diagnostics.Debug.WriteLine(localizationIndex);

            while (ind < Int32.Parse(workbook.Worksheets[localizationIndex].Columns[3].Cells[1].Value))
            {
                var newTip = new TipLibrary.Tip();
                System.Diagnostics.Debug.WriteLine(workbook.Worksheets[localizationIndex].Columns[0].Cells[ind + 2].Value);
                newTip.TipName = workbook.Worksheets[localizationIndex].Columns[0].Cells[ind + 2].Value;
                newTip.TipDescription = workbook.Worksheets[localizationIndex].Columns[1].Cells[ind + 2].Value;
                newTip.ConditionIndex = Int32.Parse(workbook.Worksheets[localizationIndex].Columns[2].Cells[ind + 2].Value);
                newTipList.Add(newTip);
                ind += 1;
            }
            System.Diagnostics.Debug.WriteLine("ff");
            return newTipList;

        }
    }
}
