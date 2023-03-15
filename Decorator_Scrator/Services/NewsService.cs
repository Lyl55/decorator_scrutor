using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Decorator_Scrator.Interfaces;
using Decorator_Scrator.Models;
using Newtonsoft.Json;

namespace Decorator_Scrator.Services
{
    public class NewsService : INewsService
    {
        public async Task<IEnumerable<NewsDto>> GetNewsAsync()
        {
            string text = await System.IO.File.ReadAllTextAsync(@"AppData\news.json");
            var news = JsonConvert.DeserializeObject<IEnumerable<NewsDto>>(text);
            return news;
        }
    }
}
