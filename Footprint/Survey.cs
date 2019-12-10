using System;
using UIKit;
using System.Collections;
using System.Collections.Generic;

namespace Footprint
{
    public class Survey : UIPickerViewModel
    {
        private List<string> _myItems;
        public int selectedIndex = 0;

        public Survey(List<string> items)
        {
            _myItems = items;
        }

        public string SelectedItem
        {
            get { return _myItems[selectedIndex]; }
        }

        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return _myItems.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return _myItems[(int)row];
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            selectedIndex = (int)row;
        }
    }
}
