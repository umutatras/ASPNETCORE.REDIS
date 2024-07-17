using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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
                _memoryCache.Set<string>("zaman", DateTime.Now.ToString());

            }
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

			//bellekteki veriyi silmeyi sağlar
			_memoryCache.Remove("zaman");
			//veriyi çekme gösterme
			ViewBag.zaman=_memoryCache.Get<string>("zaman");
			return View();
		}
	}
}
