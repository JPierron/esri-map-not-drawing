using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Vigie.Risques.Tpm.Core.Services.Core;

namespace Vigie.Risques.Tpm.Core.Services
{
    public class AkavacheCacheService : ICacheService
    {
        public AkavacheCacheService()
        {
            BlobCache.ApplicationName = "Vigie.Risques.Tpm";
            BlobCache.EnsureInitialized();
        }

        public async Task AddOrUpdateAsync<T>(string key, T value, CacheMode cacheMode)
        {
            await GetCache(cacheMode).InsertObject(key, value);
        }

        public async Task<T> GetOrFetchAsync<T>(string key, System.Func<Task<T>> fetch, CacheMode cacheMode)
        {
            return await GetCache(cacheMode).GetOrFetchObject(key, fetch).FirstOrDefaultAsync();
        }

        public async Task Shutdown()
        {
            await BlobCache.Shutdown();
        }

        private static IBlobCache GetCache(CacheMode mode)
        {
            switch (mode)
            {
                case CacheMode.Device:
                    return BlobCache.LocalMachine;
                case CacheMode.InMemory:
                    return BlobCache.InMemory;
                case CacheMode.Secure:
                    return BlobCache.Secure;
                case CacheMode.User:
                    return BlobCache.UserAccount;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
