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
        public IActionResult DeleteItem(string name)
        {
            GetDb().SetRemove(listKey, name);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            HashSet<string> keys = new HashSet<string>();
            if(GetDb().KeyExists(listKey))
            {
                foreach (var item in GetDb().SetMembers(listKey).ToList())
                {
                    keys.Add(item.ToString());

                }
            }
           
            return View(keys);
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
