using System;
using System.Threading.Tasks;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Forms;

namespace Vigie.Risques.Tpm.Tests
{
    [TestClass]
    public class IocUnitTest : TestBase
    {
        public IocUnitTest()
            :base()
        {
        }
        
        [TestMethod]
        public async Task TestCache()
        {
            var cacheService = DependencyService.Get<ICacheService>();
            var key = "testCache";
            var value = "Message de test";

            await cacheService.AddOrUpdateAsync(key, value, Core.Services.Core.CacheMode.Device);
            var cachedValue = await cacheService.GetOrFetchAsync(key, () => Task.FromResult(string.Empty), Core.Services.Core.CacheMode.Device);

            Assert.AreEqual(value, cachedValue);
        }
    }
}
