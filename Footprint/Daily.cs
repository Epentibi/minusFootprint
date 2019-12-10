using Foundation;
using System;
using System.Collections.Generic;
using UIKit;
using UserNotifications;

namespace Footprint
{
    public partial class Daily : UIViewController
    {
        List<TipLibrary.Tip> tips = new List<TipLibrary.Tip>();
        int tipImage;

        public List<int> dailyImageGeneration = new List<int>();

        public Daily(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var randomG = new System.Random();
            tipImage = randomG.Next(0, 6);
            //Tips
            int i = 0;

            while(i < 2)
            {
                Random random = new Random();
                TipLibrary.Tip tip = TipLibrary.tips[random.Next(0, TipLibrary.tips.Count - 1)];
                if(!tips.Contains(tip))
                {
                    tips.Add(tip);
                    i++;
                }
            }

            System.Diagnostics.Debug.Write("Nofsd");


            //Challenges
            var activeChallengeStrings = Filewrite.LoadChallenge();
            var activeChallenges = new List<Challenges.Challenge>();

            if (activeChallengeStrings != null && activeChallengeStrings.Count > 0)
            {
                foreach (string name in activeChallengeStrings)
                {
                    activeChallenges.Add(Challenges.LoadChallenge(name));
                    dailyImageGeneration.Add(randomG.Next(0, 6));
                }
            }
            var dailyChallengeSource = new DailyChallengeTableView(activeChallenges, tips, tipImage);
            dailyChallengeSource.viewController = this;
            DailyTable.Source = dailyChallengeSource;

            //sendNotification("Challenge Time!", "Check your daily tab to see if you have challenges unrecorded!", 5);
            //sendNotification("New Day!", "Brand new day! Go to the daily tab to see what tips we've got for you", 10);
            //sendNotification("On Track?", "Make sure you work towards your challenges to improve your lifestyle!", 15);

        }



        public void sendNotification(string Name, string Description, int Time)
        {
            var content = new UNMutableNotificationContent();
            content.Title = Name;
            content.Body = Description;
            content.Badge = 1;


            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(Time, false);

            var requestID = "sampleRequest";
            var request = UNNotificationRequest.FromIdentifier(requestID, content, trigger);

            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null)
                {
                    // Do something with error...
                }
            });
        }

        // This method will add the UIRefreshControl to the table view if  
        // it is available, ie, we are running on iOS 6+  

        void RefreshTips()
        {
            int i = 0;

            while (i < 2)
            {
                Random random = new Random();
                TipLibrary.Tip tip = TipLibrary.tips[random.Next(0, TipLibrary.tips.Count - 1)];
                if (!tips.Contains(tip))
                {
                    tips.Add(tip);
                    i++;
                }
            }
        }
        public void Refresh()
        {
            var activeChallengeStrings = Filewrite.LoadChallenge();
            var activeChallenges = new List<Challenges.Challenge>();

            if (activeChallengeStrings != null && activeChallengeStrings.Count > 0)
            {
                foreach (string name in activeChallengeStrings)
                {
                    activeChallenges.Add(Challenges.LoadChallenge(name));
                }
            }
            var dailyChallengeSource = new DailyChallengeTableView(activeChallenges, tips, tipImage);
            dailyChallengeSource.viewController = this;
            DailyTable.Source = dailyChallengeSource;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        void OnAppearing(object sender, EventArgs args)
        {

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Refresh();
        }
    }
}