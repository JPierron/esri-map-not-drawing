using System;
using System.IO;
using System.Linq;
using Vigie.Risques.Tpm.UITests.Extensions;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Vigie.Risques.Tpm.UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests : TestsBase
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void LaunchTest()
        {
            App
                .WaitForElement("HomeLabel");
            App.ScreenshotAndSave("Home screen");
        }
    }
}

