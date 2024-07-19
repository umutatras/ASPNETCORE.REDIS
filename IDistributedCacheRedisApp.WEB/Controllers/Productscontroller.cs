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

        public async Task<IActionResult> Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1);
            _cache.SetString("name", "UMUT", options);

            await _cache.SetStringAsync("surname", "Atras", options);
            return View();
        }

        public IActionResult Show()
        {
            var name=_cache.GetString("name");
            ViewBag.name = name;
            return View();

        }

        public IActionResult Remove()
        {
            _cache.Remove("name");
            return View();
        }
    }
}
