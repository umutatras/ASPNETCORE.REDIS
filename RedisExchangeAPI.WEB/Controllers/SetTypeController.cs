using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.WEB.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.WEB.Controllers
{
    public class SetTypeController : Controller
    {
        private readonly RedisService _redisService;
        private string listKey = "hashnames";

        public SetTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            if(!GetDb().KeyExists(listKey))
            {

            GetDb().KeyExpire(listKey,DateTime.Now.AddMinutes(5));
     
            }
            GetDb().SetAdd(listKey, name);
            return RedirectToAction("Index");
        }
        private IDatabase GetDb()
        {
            return _redisService.GetDb(2);
        }
    }
}
