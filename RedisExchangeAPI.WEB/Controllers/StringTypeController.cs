using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.WEB.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.WEB.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;
        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(0);
            db.StringSet("name", "umut");
            db.StringSet("ziyaretci", 100);
            return View();
        }

        public IActionResult Show()
        {
            var db = _redisService.GetDb(0);
            
            var value =db.StringGet("name");

            var range = db.StringGetRange("name", 0, 3);//0dan karakterden 3 indise kadar alır
            var length = db.StringLength("name");//uzunluğu alır
            db.StringIncrement("ziyaretci", 1);//degeri bir artırır

            var count = db.StringDecrement("ziyaretci", 1);//degeri bir azaltır
            if(value.HasValue)
            {
                ViewBag.value = value;
            }
            return View();
        }
    }
}
