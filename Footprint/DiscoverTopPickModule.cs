using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Footprint
{
    public class DiscoverTopPickModule : DiscoverModule
    {
        bool assigned;
        bool loadingComplete;

        MySqlConnectionStringBuilder connectionString;
        MySqlConnection myConnection;

        bool ConnectionFalse;

        public List<string> topChallenges = new List<string>();
        public List<Challenges.Challenge> challenges = new List<Challenges.Challenge>();

        void ProductList(IAsyncResult result) { }

        public DiscoverTopPickModule()
        {
            
           Header = NSBundle.MainBundle.GetLocalizedString("Top Picks");
           secondaryHeader = NSBundle.MainBundle.GetLocalizedString("Most popular challenges between users");
             /*
           connectionString = new MySqlConnectionStringBuilder();
           connectionString.Server = "cdb-b0rtt31n.gz.tencentcdb.com";
           connectionString.Port = 10013;
           connectionString.UserID = "root";
           connectionString.Password = "14Stork%";

           System.Diagnostics.Debug.WriteLine(connectionString.ConnectionString);
           myConnection = new MySqlConnection(connectionString.ConnectionString);
           //Connection String to Connection

           //try to connect
           try
           {
               myConnection.Open();
           }
           catch (Exception e)
           {
               System.Diagnostics.Debug.WriteLine("error, cannot connect to server");
               Console.WriteLine(e.ToString());
               ConnectionFalse = true;
               return;
           }




          MySqlCommand testCommand = new MySqlCommand("USE minusFootprint; SELECT * FROM topPicks ORDER BY selectionCount DESC LIMIT 10", myConnection);
          MySqlDataReader myReader = null;

          try
          {
              myReader = testCommand.ExecuteReader();
              while (myReader.Read())
              {
                  Console.WriteLine(myReader["challengeID"]);
                  topChallenges.Add(myReader["challengeID"].ToString());
              }
          }
          catch (Exception e)
          {
              System.Diagnostics.Debug.WriteLine("Error, Cannot Fetch Information from Server");
              Console.WriteLine(e.ToString());
              ConnectionFalse = true;
              return;
          }*/
        }

        public override async void asyncInitilize()
        {
            await ReadFrom();
            //await Task.WhenAll(task1, task2);
            System.Diagnostics.Debug.WriteLine("amount is " + challenges.Count);
            loadingComplete = true;
            uicollectionView.ReloadData();
            Console.WriteLine("DONE");
        }

        public async Task ReadFrom()
        {
            var connString = "Server=cdb-b0rtt31n.gz.tencentcdb.com;Port=10013;User Id=root;Password=14Stork%";

            try
            {
                var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                /*Console.WriteLine("Reading from SQL top picks : " + reader.GetString(0));
               // Insert some data
               using (var cmd = new MySqlCommand())
               {
                   cmd.Connection = conn;
                   cmd.CommandText = "INSERT INTO data (some_field) VALUES (@p)";
                   cmd.Parameters.AddWithValue("p", "Hello world");
                   await cmd.ExecuteNonQueryAsync();
               }*/
                // Retrieve all rows
                using (var cmd = new MySqlCommand("USE minusFootprint; SELECT * FROM topPicks ORDER BY selectionCount DESC LIMIT 10", conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                        challenges.Add(Challenges.getChallengeByID(reader.GetString(0)));

            }
            catch(Exception exception)
            {
                ConnectionFalse = true;
                System.Diagnostics.Debug.WriteLine("false");
            }
        }

        public override void collectionViewAssigned()
        {
            assigned = true;

            if(!loadingComplete)
            {

            }
            else
            {
                if (ConnectionFalse)
                {
                    expandButton.Hidden = true;
                }
                uicollectionView.ReloadData();
            }
            
        }

        public override bool secondaryHeaderVisibility()
        {
            return true;
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            if(challenges.Count == 0 && !ConnectionFalse)//not yet loaded
            {
                return 6;
            }
            else if(ConnectionFalse)//cannot 
            {
                return 6;
            }
            else//worked
            {
                return challenges[indexPath.Row].ConditionValue;
            }
        }

        public override int getRowCount()
        {
            if (challenges.Count == 0 && !ConnectionFalse)//not yet loaded
            {
                return 1;
            }
            else if (ConnectionFalse)//cannot 
            {
                if(expandButton != null)
                {
                    expandButton.Hidden = true;
                }
                return 1;
            }
            else//worked
            {
                return challenges.Count;
            }
        }

        public override UIImage getImage(NSIndexPath indexPath)
        {
            if (challenges.Count == 0 && !ConnectionFalse)//not yet loaded
            {
                return UIImage.FromFile("Image/Discover/Loading.png");
            }
            else if (ConnectionFalse)//cannot 
            {
                return UIImage.FromFile("Image/Discover/Warning.png");
            }
            else//worked
            {
                return imageManager.iconOfIndex(challenges[indexPath.Row].ConditionValue);
            }
        }

        public override string getName(NSIndexPath indexPath)
        {
            if (challenges.Count == 0 && !ConnectionFalse)//not yet loaded
            {
                return NSBundle.MainBundle.GetLocalizedString("Loading");
            }
            else if (ConnectionFalse)//cannot 
            {
                return NSBundle.MainBundle.GetLocalizedString("No Connection");
            }
            else//worked
            {
                return challenges[indexPath.Row].ChallengeName;
            }
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            if (challenges.Count == 0 && !ConnectionFalse)//not yet loaded
            {
                
            }
            else if (ConnectionFalse)//cannot 
            {
                new UIAlertView(NSBundle.MainBundle.GetLocalizedString("No Connection"), NSBundle.MainBundle.GetLocalizedString("minusFootprint cannot connect to its online database, check your internet connection or contact us at support@minusfootprint.com"), null, "OK", null).Show();
            }
            else//worked
            {
                string challengeID = challenges[indexPath.Row].ChallengeID;
                System.Diagnostics.Debug.WriteLine("Selected item " + challenges[indexPath.Row].ChallengeName + ", status of item on whether added is " + Filewrite.LoadChallenge().Contains(challengeID));

                ChallengeDetail Cpage = mainController.Storyboard.InstantiateViewController("ChallengeDetail") as ChallengeDetail;
                var CpageNavigation = new UINavigationController(Cpage);
                Cpage.challenge = challenges[indexPath.Row];
                Cpage.popView = true;
                mainController.PresentModalViewController(CpageNavigation, true);
            }
        }
    }
}
