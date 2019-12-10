using System;
using UIKit;
using System.Linq;
using System.Collections.Generic;

namespace Footprint
{
    public class SurveyPicker : UIPickerViewModel
    {
        public Dictionary<string, string> responses = new Dictionary<string, string>();

        public SurveyClass surveyClass;

        public SurveyPicker(Dictionary<string, string> response, SurveyClass survey)
        {
            responses = response;
            surveyClass = survey;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return responses.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return responses.ElementAt((int)row).Key;
        }

    }
}