using System;
using System.Collections.Generic;

namespace Footprint
{
    public static class TipLibrary
    {
        [Serializable]
        public class Tip
        {
            public string TipName;
            public string TipDescription;
            public int ConditionIndex;
            public int[] MatchingConditionindex;
            public string OvverideIconPath;
        }

        /*
        public static List<Tip> tips = new List<Tip>()
        {
            new Tip()
            {
                TipName = "Eco-Transport",
                TipDescription = "Eco-friendly transport is very importatn towards keeping our environment clean! If able to, try to walk or take a bike. Try to take metro or a bus when traveling inside cities",
                ConditionIndex = 3,
                MatchingConditionindex = new int[] {2}
            },
            new Tip()
            {
                TipName = "Fruits",
                TipDescription = "Ever feel like you need some snacks? Try to aquire some healthy local fruits rather than industrial-made snacks, they have lots of packaging and carbon-footprint !",
                ConditionIndex = 0,
                MatchingConditionindex = new int[] {-1}
            },
            new Tip()
            {
                TipName = "Affordable Food",
                TipDescription = "Think before you buy, try to eat healthy while with reasonable price",
                ConditionIndex = 2,
                MatchingConditionindex = new int[] {2,3}
            }
        };*/
        public static List<Tip> tips = ExcelReaderTest.ReadTipsExcel();

        public static List<Tip> getTipsByIndex(int index)
        {
            var list = new List<Tip>();
            foreach (Tip d in tips)
            {
                if (d.ConditionIndex == index)
                {
                    list.Add(d);
                }
            }
            return list;
        }
    }
}
