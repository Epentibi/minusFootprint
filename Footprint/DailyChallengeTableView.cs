using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Footprint.Base.lproj;

namespace Footprint
{
    public class DailyChallengeTableView : UITableViewSource
    {
        private List<Challenges.Challenge> DailyChallenges;
        public Daily viewController;
        private List<TipLibrary.Tip> dailyTips;
        int img;

        public DailyChallengeTableView(List<Challenges.Challenge> challengeName, List<TipLibrary.Tip> tips, int imageIndex)
        {
            DailyChallenges = challengeName;
            dailyTips = tips;
            img = imageIndex;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if(indexPath.Section == 1)
            {
                string iconPath = "Image/Challenge/";

                int condition = DailyChallenges[indexPath.Row].ConditionValue;

                if (condition == 0)
                {
                    iconPath += "FoodSource.png";
                }
                else if (condition == 1)
                {
                    iconPath += "FoodPrice.png";
                }
                else if (condition == 2)
                {
                    iconPath += "FoodWaste.png";
                }
                else if (condition == 3)
                {
                    iconPath += "DailyTransport.png";
                }
                else if (condition == 4)
                {
                    iconPath += "OccasionalTransport.png";
                }
                else if (condition == 5)
                {
                    iconPath += "PaperUsage.png";
                }
                else if (condition == 6)
                {
                    iconPath += "PlasticUsage.png";
                }
                else if (condition == 7)
                {
                    iconPath += "GarbageManagement.png";
                }
                else if (condition == 8)
                {
                    iconPath += "EnergyConsumption.png";
                }
                else if (condition == 9)
                {
                    iconPath += "Enviroment.png";
                }
                if (DailyChallenges[indexPath.Row].challengeType != Challenges.Challenge.ChallengeType.OneTime)
                {
                    var cell = tableView.DequeueReusableCell("TableCell") as CustomCell;
                    if (!Filewrite.NotDone(DailyChallenges[indexPath.Row].ChallengeID))
                    {
                        cell.UpdateCell(DailyChallenges[indexPath.Row].ChallengeName, UIImage.FromFile(iconPath), NSBundle.MainBundle.GetLocalizedString("COMPLETE FOR TODAY"));
                    }
                    else
                    {
                        if (DailyChallenges[indexPath.Row].RequiredDays < 3)
                        {
                            cell.UpdateCell(DailyChallenges[indexPath.Row].ChallengeName, UIImage.FromFile(iconPath), DailyChallenges[indexPath.Row].RequiredDays.ToString() + NSBundle.MainBundle.GetLocalizedString("DAYS TO GO !"));
                        }
                        else
                        {
                            cell.UpdateCell(DailyChallenges[indexPath.Row].ChallengeName, UIImage.FromFile(iconPath), NSBundle.MainBundle.GetLocalizedString("NOT DONE"));
                        }
                    }
                    if (condition == 0)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 59, 48)); //Red
                    }
                    else if (condition == 1)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 149, 0));//Organge
                    }
                    else if (condition == 2)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 204, 0));//Yellow
                    }
                    else if (condition == 3)
                    {
                        cell.UpdateColor(UIColor.FromRGB(0, 122, 255));//Dark Blue
                    }
                    else if (condition == 4)
                    {
                        cell.UpdateColor(UIColor.FromRGB(88, 86, 214));//Purple
                    }
                    else if (condition == 5)
                    {
                        cell.UpdateColor(UIColor.FromRGB(100, 210, 255));//teal blue
                    }
                    else if (condition == 6)
                    {
                        cell.UpdateColor(UIColor.FromRGB(174, 174, 178));//grey
                    }
                    else if (condition == 7)
                    {
                        cell.UpdateColor(UIColor.FromRGB(151, 234, 54));//green-yellow
                    }
                    else if (condition == 8)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 45, 85));//pink
                    }
                    else if (condition == 9)
                    {
                        cell.UpdateColor(UIColor.FromRGB(50, 215, 75));//green
                    }


                    return cell;
                }
                else
                {
                    var cell = tableView.DequeueReusableCell("TableCellNoSecond") as CustomCellLabel;
                    cell.UpdateCell(DailyChallenges[indexPath.Row].ChallengeName, UIImage.FromFile(iconPath));
                    if (condition == 0)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 59, 48)); //Red
                    }
                    else if (condition == 1)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 149, 0));//Organge
                    }
                    else if (condition == 2)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 204, 0));//Yellow
                    }
                    else if (condition == 3)
                    {
                        cell.UpdateColor(UIColor.FromRGB(0, 122, 255));//Dark Blue
                    }
                    else if (condition == 4)
                    {
                        cell.UpdateColor(UIColor.FromRGB(88, 86, 214));//Purple
                    }
                    else if (condition == 5)
                    {
                        cell.UpdateColor(UIColor.FromRGB(100, 210, 255));//teal blue
                    }
                    else if (condition == 6)
                    {
                        cell.UpdateColor(UIColor.FromRGB(174, 174, 178));//grey
                    }
                    else if (condition == 7)
                    {
                        cell.UpdateColor(UIColor.FromRGB(151, 234, 54));//green-yellow
                    }
                    else if (condition == 8)
                    {
                        cell.UpdateColor(UIColor.FromRGB(255, 45, 85));//pink
                    }
                    else if (condition == 9)
                    {
                        cell.UpdateColor(UIColor.FromRGB(50, 215, 75));//green
                    }

                    return cell;
                }
            }
            else
            {
                var cell = tableView.DequeueReusableCell("TipCell") as TipCell;

                cell.UpdateCell(dailyTips[indexPath.Row], img);
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
                return cell;
            }
        }


        public override string TitleForHeader(UITableView tableView, nint section)
        {
            if(section == 1)
            {
                return NSBundle.MainBundle.GetLocalizedString("Challenges");
            }
            else
            {
                return NSBundle.MainBundle.GetLocalizedString("Daily Tip");
            }
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if(indexPath.Section == 0)
            {
                return 230;
            }
            else
            {
                return 111;
            }
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if(section == 1)
            {
                return DailyChallenges.Count;
            }
            else
            {
                return 1;
            }
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);
            if(indexPath.Section == 0)
            {
                TipDaily f = viewController.Storyboard.InstantiateViewController("TipDaily") as TipDaily;
                f.thisTip = dailyTips[0];
                f.imageIndex = img;
                viewController.NavigationController.PushViewController(f, true);
            }
            else
            {
                DailyChallenge Cpage = viewController.Storyboard.InstantiateViewController("DailyChallenge") as DailyChallenge;
                viewController.NavigationController.PushViewController(Cpage, true);
                Cpage.challenge = DailyChallenges[indexPath.Row];
                Cpage.day = viewController;
            }
        }
    }
}
