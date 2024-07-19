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
            return View();
        }
    }
}
