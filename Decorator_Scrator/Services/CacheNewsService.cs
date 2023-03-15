using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Decorator_Scrator.Interfaces;
using Decorator_Scrator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Decorator_Scrator.Services
{
    public class CacheNewsService : INewsService
    {
        private INewsService _newsService;
        private IMemoryCache _memoryCache;
        public CacheNewsService(INewsService newsService, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _newsService = newsService;
        }

        public async Task<IEnumerable<NewsDto>> GetNewsAsync()
        {
            string key = "news";
            //check whether there is data in the cache with the key
            _memoryCache.TryGetValue(key, out IEnumerable<NewsDto> news);
            if (news!=null)
            {
                return news;
            }

            //json from service if there is no data in cache
            news = await _newsService.GetNewsAsync();
            var cache = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(10)
            };
            _memoryCache.Set(key, news, cache);
            return news;
        }
    }
}
