using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Footprint
{
    public class DiscoverSuggestTipModule : DiscoverModule
    {
        public List<TipLibrary.Tip> recommendedTips = new List<TipLibrary.Tip>();
        bool noRecommendations;

        int randomoffSet = 0;

        public DiscoverSuggestTipModule()
        {
            randomoffSet = new Random().Next(int.MinValue, int.MaxValue);

            Header = NSBundle.MainBundle.GetLocalizedString("Tips for You");

            var randomizer = new System.Random();
            var surveyResults = Filewrite.getSurveyResults();
            var tipValues = new Dictionary<int, int>();
            foreach (KeyValuePair<string, int> result in surveyResults)
            {
                int isIndex = 0;
                if (Int32.TryParse(result.Key, out isIndex))
                {
                    tipValues.Add(isIndex, result.Value);
                }
            }


            System.Diagnostics.Debug.WriteLine("number is " + tipValues.Count);

            tipValues = tipValues.OrderByDescending(key => key.Value).ToDictionary(kv => kv.Key, kv => kv.Value);

            while (recommendedTips.Count < 10 && tipValues.Count > 0)
            {
                int i = 0;
                if (tipValues.ElementAt(0).Value > 8)
                {
                    i = randomizer.Next(2, 3);
                }
                else if (tipValues.ElementAt(0).Value > 6)
                {
                    i = randomizer.Next(2, 3);
                }
                else if (tipValues.ElementAt(0).Value > 5)
                {
                    i = randomizer.Next(1, 3);
                }
                else if (tipValues.ElementAt(0).Value > 4)
                {
                    i = randomizer.Next(1, 2);
                }
                else
                {
                    i = randomizer.Next(1, 2);
                }
                var list = TipLibrary.getTipsByIndex(tipValues.ElementAt(0).Key);
                int count = list.Count;
                if (i > count)
                {
                    i = count;
                }

                while (i > 0)
                {
                    var thisTip = list[randomizer.Next(0, count)];
                    while (recommendedTips.Contains(thisTip))
                    {
                        thisTip = list[randomizer.Next(0, count)];
                    }
                    recommendedTips.Add(thisTip);
                    i -= 1;
                }

                tipValues.Remove(tipValues.ElementAt(0).Key);
            }

            if (recommendedTips.Count < 1)
            {
                noRecommendations = true;
            }

            ShuffleMe(recommendedTips);
        }


        public override bool addButtomVisibility()
        {
            if (noRecommendations)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ShuffleMe<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }



        public override int getRowCount()
        {
            if (recommendedTips.Count > 0)
            {
                return recommendedTips.Count;
            }
            else
            {
                return 1;
            }
        }

        public override int getColorCode(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return 3;
            }
            else
            {
                return recommendedTips[indexPath.Row].ConditionIndex;
            }
        }

        public override UIImage getImage(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return UIImage.FromFile("Image/Discover/Info.png");
            }
            else
            {
                return imageManager.iconOfIndex(recommendedTips[indexPath.Row].ConditionIndex);
            }
        }

        public override string getName(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return NSBundle.MainBundle.GetLocalizedString("No Surveys Done");
            }
            else
            {
                return recommendedTips[indexPath.Row].TipName;
            }
        }

        public override void itemSelected(NSIndexPath indexPath)
        {
            if (noRecommendations)
            {
                return;
            }

            int imageIndex = new Random(indexPath.Row + randomoffSet).Next(0, 6);

            TipDaily f = mainController.Storyboard.InstantiateViewController("TipDaily") as TipDaily;
            f.thisTip = recommendedTips[indexPath.Row];
            f.imageIndex = imageIndex;
            f.controller = mainController;
            mainController.PresentViewController(f, true, null);
        }
    }
}
