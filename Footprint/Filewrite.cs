using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UIKit;
using System.Drawing;
using Foundation;

namespace Footprint
{
    public static class Filewrite
    {
        static float defaultVersion = 1.1f;

        [Serializable]
        public class Survey
        {
            public List<string> Surveys;

            public int SurveyR_TypeOfFood;

            public int SurveyR_SourceOfFood;

            public int SurveyR_UsageOfFood;

            public int SurveyR_DailyTransport;
            public int SurveyR_DailyTransportX;

            public int SurveyR_OccasionalTransport;

            public List<int> ToBeImproved = new List<int>();
        }

        [Serializable]
        public class ChallengeSave
        {
            public List<string> challenges = new List<string>();

            public int TotalChallenge;
        }

        [Serializable]
        public class DailyChallengeDate
        {
            public DateTime date;
            public DateTime creationDate;
            public bool saved;
        }

        [Serializable]
        public class Personal
        {
            public string UserName;
            //public UIImage image;
            public string Image;

            public Dictionary<string, int> surveyData = new Dictionary<string, int>();
        }

        [Serializable]
        public class Version
        {
            public float version;
        }

        public static void CompleteChallenge()
        {
            ChallengeSave data = new ChallengeSave();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/challengeList"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/challengeList");
                data = (ChallengeSave)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/challengeList");

            BinaryFormatter b1f = new BinaryFormatter();

            data.TotalChallenge += 1;

            b1f.Serialize(file, data);
            file.Close();
        }

        public static void UpdateVersion (float version)
        {
            Version data = new Version();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/update"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/update");
                data = (Version)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/update");

            BinaryFormatter b1f = new BinaryFormatter();

            data.version = version;

            b1f.Serialize(file, data);
            file.Close();
        }

        public static float loadVersion()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/update"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/update");
                if (file.Length < 1)
                {
                    file.Close();
                    return defaultVersion;
                }

                Version data = (Version)bf.Deserialize(file);
                float d = data.version;
                file.Close();
                return d;
            }
            else
            {
                return defaultVersion;
            }
        }


        public static void UpdateUsername(string name)
        {
            Personal data = new Personal();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/user_personal"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/user_personal");
                data = (Personal)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/user_personal");

            BinaryFormatter b1f = new BinaryFormatter();

            data.UserName = name;

            b1f.Serialize(file, data);
            file.Close();
        }

        public static void AddSurveyResult(string key, int returnValue)
        {
            Personal data = new Personal();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/user_personal"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/user_personal");
                if(f.Length > 0)
                {
                    data = (Personal)bf.Deserialize(f);
                }
                f.Close();
            }
            FileStream file = File.Create(documents + "/user_personal");

            BinaryFormatter b1f = new BinaryFormatter();

            if(data.surveyData != null && !data.surveyData.ContainsKey(key))
            {
                data.surveyData.Add(key, returnValue);
            }
            else
            {
                data.surveyData[key] = returnValue;
            }

            b1f.Serialize(file, data);
            file.Close();
        }

        public static bool Exist(string key)
        {
            Personal data = new Personal();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/user_personal"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/user_personal");
                if (f.Length > 0)
                {
                    data = (Personal)bf.Deserialize(f);
                }
                f.Close();
            }

            return data.surveyData.ContainsKey(key);
        }

        public static Dictionary<string, int> getSurveyResults()
        {
            Personal data = new Personal();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/user_personal"))
            {
                System.Diagnostics.Debug.WriteLine("existed");
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/user_personal");
                if (f.Length > 0)
                {
                    data = (Personal)bf.Deserialize(f);
                }
                f.Close();
            }

            return data.surveyData;
        }

        public static void UpdateAvatar(UIImage img)
        {
            var filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Profile.jpg";
            NSData image = img.AsJPEG();
            NSError err = null;
            image.Save(filename, false, out err);
        }

        public static void DeleteAll()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] filePaths = Directory.GetFiles(documents);
            foreach (string filePath in filePaths)
                File.Delete(filePath);

            string[] f = Directory.GetFiles(documents + "/Date");
            foreach (string filePath in f)
                File.Delete(filePath);

        }

        public static void AddChallenge(string ChallengeID)
        {
            ChallengeSave data = new ChallengeSave();
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/challengeList"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/challengeList");
                data = (ChallengeSave)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/challengeList");

            BinaryFormatter b1f = new BinaryFormatter();

            data.challenges.Add(ChallengeID);

            b1f.Serialize(file, data);
            file.Close();
        }

        public static void RemoveChallenge(string ChallengeID)
        {
            ChallengeSave data = new ChallengeSave();

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/challengeList"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/challengeList");
                data = (ChallengeSave)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/challengeList");

            BinaryFormatter b1f = new BinaryFormatter();

            data.challenges.Remove(ChallengeID);

            b1f.Serialize(file, data);
            file.Close();
        }

        public static void RemoveConfig()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Config"))
            {
                File.Delete(documents + "/Config");
            }
        }

        public static List<string> LoadSurvey()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Config"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/Config");
                if (file.Length < 1)
                {
                    file.Close();
                    return null;
                }

                Survey data = (Survey)bf.Deserialize(file);
                List<string> d = data.Surveys;
                file.Close();
                return d;
            }
            else
            {
                return null;
            }
        }

        public static List<string> LoadChallenge()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/challengeList"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/challengeList");
                if (file.Length < 1)
                {
                    file.Close();
                    return new List<string>();
                }

                ChallengeSave data = (ChallengeSave)bf.Deserialize(file);
                List<string> d = data.challenges;
                file.Close();
                return d;
            }
            else
            {
                return new List<string>();
            }
        }

        public static int totalChallenges()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/challengeList"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/challengeList");
                if (file.Length < 1)
                {
                    file.Close();
                    return 0;
                }

                ChallengeSave data = (ChallengeSave)bf.Deserialize(file);
                var d = data.TotalChallenge;
                file.Close();
                return d;
            }
            else
            {
                return 0;
            }
        }

        public static string LoadUsername()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/user_personal"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/user_personal");
                if (file.Length < 1)
                {
                    file.Close();
                    return null;
                }

                Personal data = (Personal)bf.Deserialize(file);
                string d = data.UserName;
                file.Close();
                return d;
            }
            else
            {
                return null;
            }
        }

        public static UIImage LoadAvatar()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Profile.jpg"))
            {
                var d = UIImage.FromFile(documents + "/Profile.jpg");
                return d;
            }
            else
            {
                return null;
            }
        }

        public static void SaveDay(string challengeID)
        {
            DailyChallengeDate data = new DailyChallengeDate();

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(documents + "/Date"))
            {
                Directory.CreateDirectory(documents + "/Date");
            }

            if (File.Exists(documents + "/Date/" + challengeID))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/Date/" + challengeID);
                data = (DailyChallengeDate)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/Date/" + challengeID);
            BinaryFormatter b1f = new BinaryFormatter();

            data.saved = true;
            data.date = DateTime.Now;
            //Update Information Here

            b1f.Serialize(file, data);
            file.Close();
        }

        public static void CreationDay(string challengeID)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var data = new DailyChallengeDate();

            if (!Directory.Exists(documents + "/Date"))
            {
                Directory.CreateDirectory(documents + "/Date");
            }
            data.creationDate = DateTime.Now;

            FileStream file = File.Create(documents + "/Date/" + challengeID);
            BinaryFormatter b1f = new BinaryFormatter();
            b1f.Serialize(file, data);
            file.Close();
        }

        public static bool NotDone(string challengeID)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Date/" + challengeID))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/Date/" + challengeID);
                if (file.Length < 1)
                {
                    file.Close();
                    return true;
                }

                DailyChallengeDate DATA = (DailyChallengeDate)bf.Deserialize(file);
                file.Close();

                if(DATA.date.Year == DateTime.Now.Year && DATA.date.Month == DateTime.Now.Month && DATA.date.Day == DateTime.Now.Day)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool StreakBroken(string challengeID)
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Date/" + challengeID))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenRead(documents + "/Date/" + challengeID);
                if (file.Length < 1)
                {
                    file.Close();
                    return true;
                }

                DailyChallengeDate DATA = (DailyChallengeDate)bf.Deserialize(file);
                file.Close();

                if (DATA.creationDate.Date == DateTime.Now.Date)
                {
                    System.Diagnostics.Debug.WriteLine("Creation day");
                    return false;
                }

                if(DATA.saved)
                {
                    if((DateTime.Now.Date - DATA.date.Date).Days >= 2)
                    {
                        System.Diagnostics.Debug.WriteLine("broken streak saved date more of equal to 2 days");
                        return true;
                    }
                }
                else
                {
                    if ((DateTime.Now.Date - DATA.creationDate.Date).Days >= 2)
                    {
                        System.Diagnostics.Debug.WriteLine("broken streak nosaved date more of equal to 2 days with creation");
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return true;
            }
        }

        public static void SaveSurvey(List<string> survey)
        {
            Survey data = new Survey();

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (File.Exists(documents + "/Config"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream f = File.OpenRead(documents + "/Config");
                data = (Survey)bf.Deserialize(f);
                f.Close();
            }
            FileStream file = File.Create(documents + "/Config");
            BinaryFormatter b1f = new BinaryFormatter();

            data.Surveys = survey;
            //Update Information Here

            b1f.Serialize(file, data);
            file.Close();
        }

        

    }
}
