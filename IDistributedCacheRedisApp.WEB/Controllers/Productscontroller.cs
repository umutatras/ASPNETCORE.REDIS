using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace IDistributedCacheRedisApp.WEB.Controllers
{
    public class Productscontroller : Controller
    {
        private readonly IDistributedCache _cache;

        public Productscontroller(IDistributedCache cache)
        {
            _cache = cache;
        }

        public IActionResult Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1);
            _cache.SetString("name", "UMUT", options);
            return View();
        }
    }
}
