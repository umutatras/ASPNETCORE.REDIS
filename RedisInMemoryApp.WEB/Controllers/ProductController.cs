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
			return View();
		}
	}
}
