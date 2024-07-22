using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.WEB.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.WEB.Controllers
{
    public class SortedTypeController : Controller
    {
        private readonly RedisService _redisService;
        private string listKey = "sortedsetnames";
        public SortedTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

       
        public IActionResult Index()
        {
            HashSet<string> keys = new HashSet<string>();

            if(GetDb().KeyExists(listKey))
            {
                foreach (var item in GetDb().SortedSetScan(listKey).ToList())
                {
                    keys.Add(item.ToString());
                };

                foreach (var item in GetDb().SortedSetRangeByRank(listKey, order: Order.Ascending).ToList())
                {
                    keys.Add(item.ToString());
                }
            }
            return View(keys);
        }
        public IActionResult DeleteItem(string name)
        {
            GetDb().SortedSetRemove(listKey, name);
            return RedirectToAction("Index");
        }


        public IActionResult Add(string name,int score)
        {
            GetDb().KeyExpire(listKey, DateTime.Now.AddMinutes(1));
            GetDb().SortedSetAdd(listKey,name,score);
            return RedirectToAction("Index");
        }
        public IDatabase GetDb()
        {
            return _redisService.GetDb(1);
        }
    }
}
