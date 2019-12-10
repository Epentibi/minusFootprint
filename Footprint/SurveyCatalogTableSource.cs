using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using System.Linq;
using Footprint.Base.lproj;

namespace Footprint
{
    public class SurveyCatalogTableSource : UITableViewSource
    {
        SurveyMenu SurveyMenu;

        public Dictionary<string, bool> surveys = new Dictionary<string, bool>();

        public SurveyCatalogTableSource(Dictionary<string, bool> dictionary, SurveyMenu menu)
        {
            surveys = dictionary;
            SurveyMenu = menu;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = surveys.ElementAt(indexPath.Row).Key;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return surveys.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            System.Diagnostics.Debug.WriteLine("Selected item " + surveys.ElementAt(indexPath.Row).Key);
            SurveyMenu.OpenSurvey(surveys.ElementAt(indexPath.Row).Key);
            tableView.DeselectRow(indexPath, true);
        }

    }
}
