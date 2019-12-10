// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Footprint.Base.lproj
{
    [Register ("SurveyView")]
    partial class SurveyView
    {
        [Outlet]
        UIKit.UIButton nextButton { get; set; }


        [Outlet]
        UIKit.UIPickerView picker { get; set; }


        [Outlet]
        UIKit.UITextView question { get; set; }


        [Outlet]
        UIKit.UILabel surveyLabel { get; set; }


        [Action ("next:")]
        partial void next (Foundation.NSObject sender);

        void ReleaseDesignerOutlets ()
        {
        }
    }
}