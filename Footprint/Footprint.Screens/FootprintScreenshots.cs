using System;
using Xnapshot;
using Xamarin.UITest;

namespace Footprint.Screens
{
    public class FootprintScreenshots : Xnapshot.Screenshots
    {
        public FootprintScreenshots() : base(
    "iOS-12-2",
    "/Users/jingchengyang/Desktop",
    "/Users/jingchengyang/Projects/Footprint/Footprint/bin/iPhoneSimulator/Debug/device-builds/iphone12.3-13.0/Footprint.app",
    new[] {
          "iPhone-8",
          "iPhone-SE"
    })
        {
        }


        protected override void SetAppStateForScreenshot1()
        {

        }

        protected override void SetAppStateForScreenshot2()
        {
            App.Tap(c => c.Marked("Discover_Tab"));
            //App.Tap(v => v.Text("Silver Ratio"));
            //App.Tap(c => c.Marked("Done"));
        }
    }
}