using Vigie.Risques.Tpm.Core.Services.Contracts;
using Vigie.Risques.Tpm.Core.Services.Core;
using Vigie.Risques.Tpm.Core.Services.Mocks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(MockCacheService))]
namespace Vigie.Risques.Tpm.Core.Services.Mocks
{
    public class MockCacheService : ICacheService
    {
        private readonly Dictionary<string, object> _cache;

        public MockCacheService()
        {
            _cache = new Dictionary<string, object>();
        }

        public async Task AddOrUpdateAsync<T>(string key, T value, CacheMode cacheMode)
        {
            if (_cache.ContainsKey(key))
            {
                _cache[key] = value;
            }
            else
            {
                _cache.Add(key, value);
            }

            await Task.FromResult(0);
        }

        public async Task<T> GetOrFetchAsync<T>(string key, Func<Task<T>> fetch, CacheMode cacheMode)
        {
            await Task.FromResult(0);

            return (T)_cache[key];
        }

        public async Task Shutdown()
        {
            await Task.FromResult(0);
        }
    }
}
