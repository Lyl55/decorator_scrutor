using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Decorator_Scrator.Models;

namespace Decorator_Scrator.Interfaces
{
    public interface INewsService
    {
        public Task<IEnumerable<NewsDto>> GetNewsAsync();
    }
}
