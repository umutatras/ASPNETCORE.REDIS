using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.WEB.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.WEB.Controllers
{
    public class ListTypeController : Controller
    {
        private readonly RedisService _redisService;
        private string listKey = "names";
        public ListTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db=GetDb();
            return View();
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            GetDb().ListRightPush(listKey,name);
            return View();  
        }

        private IDatabase GetDb()
        {
           return _redisService.GetDb(1);
        }
    }
}
