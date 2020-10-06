using System.IO;
using NUnit.Framework;
using Xamarin.UITest;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Vigie.Risques.Tpm.Core.Services.Mocks;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.UITests
{
    public abstract class TestsBase
    {
        protected TestsBase(Platform platform)
        {
            Platform = platform;
        }

        public IApp App { get; protected set; }

        public Platform Platform { get; protected set; }

        [OneTimeSetUp]
        public virtual void BeforEachTestRun()
        {
            Directory.CreateDirectory(Config.LogFolder);
        }

        [SetUp]
        public virtual void BeforeEachTest()
        {
            App = AppInitializer.StartApp(Platform);
            Setup();
        }

        protected virtual void Setup()
        {
            DependencyService.Register<ICacheService, MockCacheService>();
        }
    }
}

