using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Footprint
{
    public class ChallengeTableViewSource : UITableViewSource
    {
        private List<Challenges.Challenge> ThischallengeName;
        public ChallengePage page;

        int index;

        int sections;

        public ChallengeTableViewSource(List<Challenges.Challenge> challengeName, nint selectedSegmentValue)
        {
            var ExistingChallenges = Filewrite.LoadChallenge();
            ThischallengeName = challengeName;
            index = (int)selectedSegmentValue;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "" );
            cell.TextLabel.Text = ThischallengeName[indexPath.Row].ChallengeName;
            cell.ContentView.Layer.CornerRadius = 10;
            cell.TextLabel.Font = UIFont.BoldSystemFontOfSize(20);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ThischallengeName.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            ChallengeDetail Cpage = page.Storyboard.InstantiateViewController("ChallengeDetail") as ChallengeDetail;
            page.NavigationController.PushViewController(Cpage, true);
            Cpage.challenge = ThischallengeName[indexPath.Row];
            Cpage.pg = page;
        }

    }
}
