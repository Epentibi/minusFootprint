using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Footprint
{
    public partial class ChallengePage : UIViewController
    {

        public UITableView tableView;

        Dictionary<string, int> listDirectories = new Dictionary<string, int>();
        Dictionary<int, int> indexDirectories = new Dictionary<int, int>();

        List<Challenges.Challenge> Clist = new List<Challenges.Challenge>();
        List<Challenges.Challenge> newList = new List<Challenges.Challenge>();

        SortedDictionary<string, int> alphabetical;
        SortedDictionary<int, int> type;

        public ChallengePage (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            System.Diagnostics.Debug.WriteLine("return new");

            tableView = ChallengeTable;

            var list = Filewrite.LoadChallenge();
            Clist = Challenges.challengeList;

            int l = 0;


            if (list != null && list.Count > 0)
            {
                foreach (Challenges.Challenge d in Clist)
                {
                    if (list.Contains(d.ChallengeID))
                    {

                    }
                    else
                    {
                        newList.Add(d);
                        listDirectories.Add(d.ChallengeID, l);
                        indexDirectories.Add(l, d.ConditionValue);
                        l += 1;
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("CLIST");
                foreach (Challenges.Challenge d in Clist)
                {
                    newList.Add(d);
                    listDirectories.Add(d.ChallengeID, l);
                    indexDirectories.Add(l, d.ConditionValue);
                    l += 1;
                }
            }

            alphabetical = new SortedDictionary<string, int>(listDirectories);

            

            Clist.Clear();

            foreach (KeyValuePair<string, int> value in alphabetical)
            {
                Clist.Add(newList[value.Value]);
            }


            var ChallengeSource = new ChallengeTableViewSource(Clist, 0);
            ChallengeTable.Source = ChallengeSource;
            ChallengeTable.RowHeight = 50;
            ChallengeSource.page = this;

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        partial void segmentValueChanged(NSObject sender)
        {
            if(segmentController.SelectedSegment == 0) //alphabetical
            {
                Clist.Clear();

                foreach (KeyValuePair<string, int> value in alphabetical)
                {
                    Clist.Add(newList[value.Value]);
                }

            }
            else
            {
                Clist.Clear();

                var val = indexDirectories.OrderBy(pair => pair.Value);

                foreach (KeyValuePair<int, int> value in val)
                {
                    Clist.Add(newList[value.Key]);
                }
            }

            System.Diagnostics.Debug.WriteLine("switched " + segmentController.SelectedSegment);

            var ChallengeSource = new ChallengeTableViewSource(Clist, segmentController.SelectedSegment);
            ChallengeTable.Source = ChallengeSource;
            ChallengeTable.RowHeight = 50;
            ChallengeSource.page = this;
        }
    }
}