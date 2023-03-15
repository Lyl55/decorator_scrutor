using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Decorator_Scrator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Decorator_Scrator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _newsService.GetNewsAsync());
        }
    }
}
