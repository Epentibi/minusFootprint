using System;
using Xnapshot;

namespace Footprint.Screens
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var screenshots = new FootprintScreenshots();
            screenshots.TakeScreenshots();

            Environment.Exit(0);
        }
    }
}
