using Vigie.Risques.Tpm.Core.Services.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Vigie.Risques.Tpm.Core.Services.Contracts
{
    public interface ICacheService
    {
        Task AddOrUpdateAsync<T>(string key, T value, CacheMode cacheMode);

        Task<T> GetOrFetchAsync<T>(string key, Func<Task<T>> fetch, CacheMode cacheMode);

        Task Shutdown();
    }
}
