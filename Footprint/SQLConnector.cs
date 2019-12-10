using System;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Footprint
{
    public static class SQLConnector
    {

        static MySqlConnectionStringBuilder connectionString;
        static MySqlConnection myConnection;

        public static bool ConnectionFalse;

        static SQLConnector()
        {
         /*   
            connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "cdb-b0rtt31n.gz.tencentcdb.com";
            connectionString.Port = 10013;
            connectionString.UserID = "root";
            connectionString.Password = "14Stork%";


            myConnection = new MySqlConnection(connectionString.ConnectionString);
            //Connection String to Connection

            //try to connect
            myConnection.Open();*/
        }

        public static async void SaveChallenge(string challengeID)
        {
            /*
           challengeID = "'" + challengeID + "'";
           MySqlCommand testCommand = new MySqlCommand("use minusFootprint; INSERT IGNORE INTO topPicks VALUES("+ challengeID + ", 0); UPDATE topPicks SET challengeID = " + challengeID + ", selectionCount = selectionCount + 1 WHERE challengeID = " + challengeID + " LIMIT 1; ", myConnection);
           MySqlDataReader myReader = null;

           try
           {
               myReader = testCommand.ExecuteReader();
               while (myReader.Read())
               {

               }
           }
           catch (Exception e)
           {
               System.Diagnostics.Debug.WriteLine("Error, Cannot Fetch Information from Server");
               Console.WriteLine(e.ToString());
               return false;
           }
           return true;*/
            challengeID = "'" + challengeID + "'";
            await uploadChallengeFile(challengeID);
        }

        static async Task<bool> uploadChallengeFile(string challengeID)
        {
            var connString = "Server=cdb-b0rtt31n.gz.tencentcdb.com;Port=10013;User Id=root;Password=14Stork%";
            try
            {
                var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "use minusFootprint; INSERT IGNORE INTO topPicks VALUES(" + challengeID + ", 0); UPDATE topPicks SET challengeID = " + challengeID + ", selectionCount = selectionCount + 1 WHERE challengeID = " + challengeID + " LIMIT 1; ";
                    await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("false" + challengeID);
                Console.WriteLine(exception);
                return false;
            }

            return true;
        }

         public static async void executeAsyncQuery(string  function)
        {
            await asyncQuerySent(function);
        }

        static async Task asyncQuerySent(string function)
        {
            var connString = "Server=cdb-b0rtt31n.gz.tencentcdb.com;Port=10013;User Id=root;Password=14Stork%";
            try
            {
                var conn = new MySqlConnection(connString);
                await conn.OpenAsync();

                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = function;
                    await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("async quesry sent false");
                Console.WriteLine(exception);
            }
        }
    }
}
