using System;
using System.ComponentModel;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using Foundation;
using UIKit;
using System.IO;

namespace Footprint
{
    public class DiscoverEditorPickModule : DiscoverModule
    {
        bool assigned;
        bool downloadComplete;

        bool downloadFailed;

        public List<Challenges.Challenge> challenges = new List<Challenges.Challenge>();



        public DiscoverEditorPickModule()
        {
            Header = NSBundle.MainBundle.GetLocalizedString("Editor Picks");
            secondaryHeader = NSBundle.MainBundle.GetLocalizedString("Challenges selected weekly by our editors");

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Exception exc = null;

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += ((sender, args) =>
                    {
                        if (args.Error == null)
                        {
                            Completed(sender, args);
                        }
                        else
                        {
                            downloadFailed = true;
                            System.Diagnostics.Debug.WriteLine("Download failed from BOD Static Server for Editor Pick Module");
                            uicollectionView.ReloadData();
                            //HandleWebClientException(args.Error);
                        }
                    });

                    webClient.DownloadFileAsync(new Uri("https://footprint-1259598834.cos.ap-chengdu.myqcloud.com/editorPick.xml"), documents + "/editorPick.xml");

                }
            }
            catch (Exception ex)
            {
                downloadFailed = true;
                System.Diagnostics.Debug.WriteLine("Download failed from BOD Static Server for Editor Pick Module");
                uicollectionView.ReloadData();
            }
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if(downloadFailed)
            {
                //this is where doenload fail happens
                expandButton.Hidden = true;
                uicollectionView.ReloadData();
                System.Diagnostics.Debug.WriteLine("Download failed! for complete handler editor pick module");
                return;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Download completed!");
            }
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            XmlReader xtr = XmlReader.Create(documents + "/editorPick.xml");

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "challenge")
                {
                    challenges.Add(Challenges.getChallengeByID(xtr.GetAttribute("ID")));
                }
            }
            downloadComplete = true;
            if (assigned)
            {
                uicollectionView.ReloadData();
            }
        }

        public override void collectionViewAssigned()
        {
            assigned = true;
            if(downloadComplete)
            {
                uicollectionView.ReloadData();
            }
        }

        public override int getRowCount()
        {
            if(!downloadComplete && !downloadFailed)//loading
            {
                return 1;
            }
            else if(downloadFailed)//failed
            {
                return 1;
            }
            else//normal
            {
                return challenges.Count;
            }
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            if (!downloadComplete && !downloadFailed)//loading
            {
                return 6;
            }
            else if (downloadFailed)//failed
            {
                return 6;
            }
            else//normal
            {
                System.Diagnostics.Debug.WriteLine(indexPath.Row);
                return challenges[indexPath.Row].ConditionValue;
            }
        }

        public override string getName(NSIndexPath indexPath)
        {
            if (!downloadComplete && !downloadFailed)//loading
            {
                return NSBundle.MainBundle.GetLocalizedString("Loading");
            }
            else if (downloadFailed)//failed
            {
                return NSBundle.MainBundle.GetLocalizedString("No Connection");
            }
            else//normal
            {
                return challenges[indexPath.Row].ChallengeName;
            }
        }

        public override UIImage getImage(NSIndexPath indexPath)
        {
            if (!downloadComplete && !downloadFailed)//loading
            {
                return UIImage.FromFile("Image/Discover/Loading.png");
            }
            else if (downloadFailed)//failed
            {
                return UIImage.FromFile("Image/Discover/Warning.png");
            }
            else//normal
            {
                return imageManager.iconOfIndex(challenges[indexPath.Row].ConditionValue);
            }
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            if (!downloadComplete && !downloadFailed)//loading
            {

            }
            else if (downloadFailed)//failed
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

        public override bool secondaryHeaderVisibility()
        {
            return true;
        }

        public override bool expansionButtonVisibility()
        {
            if(downloadFailed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
