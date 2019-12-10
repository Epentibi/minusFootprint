using System;
using System.Collections.Generic;
using Foundation;
using Footprint.Base.lproj;
using UIKit;

namespace Footprint
{
    public class JustTableViewSource : UITableViewSource
    {
        public List<string> firstColumn = new List<string>() { "Survey", "Achievements", "More" };
        public List<string> secondColumn = new List<string>() { "About" };

        UIViewController page;

        public JustTableViewSource(UIViewController view)
        {
            page = view;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 0)
            {
                //var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
                var cell = tableView.DequeueReusableCell("Table") as JustCell;

                if(indexPath.Row == 0)
                {
                    cell.UpdateCell(NSBundle.MainBundle.GetLocalizedString("Survey"), UIImage.FromFile("Image/Me_Icons/Survey.png"));
                }
                else if (indexPath.Row == 1)
                {
                    cell.UpdateCell(NSBundle.MainBundle.GetLocalizedString("Achievements"), UIImage.FromFile("Image/Me_Icons/Achievement.png"));
                }
                else if(indexPath.Row == 2)
                {
                    cell.UpdateCell(NSBundle.MainBundle.GetLocalizedString("More"), UIImage.FromFile("Image/Me_Icons/More.png"));
                }
                else
                {
                    cell.UpdateCell(firstColumn[indexPath.Row], null);
                }
                return cell;
            }
            else
            {
                var cell = tableView.DequeueReusableCell("Table") as JustCell;
                if (indexPath.Row == 0)
                {
                    cell.UpdateCell(NSBundle.MainBundle.GetLocalizedString("About"), UIImage.FromFile("Image/Me_Icons/About.png"));
                }
                else
                {
                    cell.UpdateCell(secondColumn[indexPath.Row], null);
                }
                return cell;
            }

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if(section == 0)
            {
                return 3;
            }
            else
            {
                return 1;
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            if(indexPath.Section == 0)
            {
                if(indexPath.Row == 0)
                {
                    SurveyMenu Cpage = page.Storyboard.InstantiateViewController("SurveyMenu") as SurveyMenu;
                    page.NavigationController.PushViewController(Cpage, true);
                }
                else if (indexPath.Row == 1)
                {
                    Achievements Cpage = page.Storyboard.InstantiateViewController("Achievement") as Achievements;
                    page.NavigationController.PushViewController(Cpage, true);
                }
                else if(indexPath.Row == 2)
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.minusfootprint.com"));
                }
            }
            else if(indexPath.Section == 1)
            {
                if(indexPath.Row == 0)
                {
                    About Cpage = page.Storyboard.InstantiateViewController("About") as About;
                    page.NavigationController.PushViewController(Cpage, true);
                }
            }
        }
    }
}
