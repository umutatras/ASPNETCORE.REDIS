using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RedisInMemoryApp.WEB.Models;

namespace RedisInMemoryApp.WEB.Controllers
{
	public class ProductController : Controller
	{
		private  IMemoryCache _memoryCache;
		public ProductController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}
		public IActionResult Index()
		{
			//değerin bellekte olup olmadığını kontrol etme
			if(String.IsNullOrEmpty(_memoryCache.Get<string>("zaman")))
			{
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString());

            }
			if(!_memoryCache.TryGetValue("zaman",out  string zaman))
			{
				//geçerlilik süresi oluşturma sınıfı
				MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();
				options.AbsoluteExpiration=DateTime.Now.AddSeconds(30);
				options.SlidingExpiration=TimeSpan.FromSeconds(30);

				options.Priority = CacheItemPriority.High;

				options.RegisterPostEvictionCallback((key, value, reason, state) =>
				{
					_memoryCache.Set("callback", $"{key}->{value}=>sebep:{reason}");
				});
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options);

            }
			Product p = new Product { Id = 1, Name = "Kalem", Price = 5 };
			_memoryCache.Set<Product>("product:1", p);
            //değeri set etme key value şeklindedir.
            _memoryCache.Set<string>("zaman", DateTime.Now.ToString());
			return View();
		}

		public IActionResult Show()
		{
			//veriyi önce dbden almaya çalışır yoksa set eder
			_memoryCache.GetOrCreate<string>("zaman", entry =>
			{
				return DateTime.Now.ToString();
			});
			_memoryCache.TryGetValue("callback", out string callback);
			ViewBag.callback = callback;
			ViewBag.product = _memoryCache.Get<Product>("product:1");
			//bellekteki veriyi silmeyi sağlar
			_memoryCache.Remove("zaman");
			//veriyi çekme gösterme
			ViewBag.zaman=_memoryCache.Get<string>("zaman");
			return View();
		}
	}
}
