using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Vigie.Risques.Tpm.UITests.Extensions
{
    public static class AppExtentions
    {
        private const string _screenshotPrefix = "screenshot-";
        private const char _charReplacement = '_';

        public static IApp WaitTime(this IApp app, TimeSpan time)
        {
            System.Threading.Thread.Sleep(time);

            return app;
        }

        public static IApp WaitAndTapItem(this IApp app, string item)
        {
            app.WaitForElement(item);
            app.Tap(item);

            return app;
        }

        public static IApp WaitItemAndTapAnother(this IApp app, string itemToWait, string itemToTap)
        {
            app.WaitForElement(itemToWait);
            app.Tap(itemToTap);

            return app;
        }

        public static IApp AssertItemExists(this IApp app, string item, string errorMessage)
        {
            var findCtrl = app.Query(item).FirstOrDefault();
            Assert.IsNotNull(findCtrl, errorMessage);

            return app;
        }

        public static IApp ScreenshotAndSave(this IApp app, string screenshotName, [CallerMemberName]string caller = "")
        {
            WaitTime(app, TimeSpan.FromMilliseconds(500));
            var sc = app.Screenshot(screenshotName);

            string destination = Path.Combine(Config.LogFolder, caller);
            Directory.CreateDirectory(destination);

            destination = Path.Combine(
                destination,
                string.Format(
                    "{0}_{1}_{2}_{3}.png",
                    caller,
                    DateTime.Now.ToString("yyyyMMdd_HHmmssfff"),
                    Path.GetFileNameWithoutExtension(sc.FullName).Replace(_screenshotPrefix, string.Empty),
                    SanitizeString(screenshotName)));
            sc.MoveTo(destination);

            return app;
        }

        private static string SanitizeString(string text)
        {
            text = text.Replace(' ', _charReplacement);

            foreach (var illegalChar in Path.GetInvalidFileNameChars())
            {
                text = text.Replace(illegalChar, _charReplacement);
            }

            return text;
        }
    }
}
