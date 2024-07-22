using Microsoft.AspNetCore.Mvc;
using RedisExchangeAPI.WEB.Services;
using StackExchange.Redis;

namespace RedisExchangeAPI.WEB.Controllers
{
    public class HashTypeController : Controller
    {
        private readonly RedisService _redisService;
        private string listKey = "dictionary";

        public HashTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            Dictionary<string,string>list= new Dictionary<string,string>();
            if(GetDb().KeyExists(listKey))
            {
                foreach (var item in GetDb().HashGetAll(listKey).ToList())
                {
                    list.Add(item.Name,item.Value);
                }
            }
            return View(list);
        }
        public IActionResult DeleteItem(string name)
        {
            GetDb().HashDelete(listKey, name);
            return RedirectToAction("Index");
        }

        public IActionResult Add(string key,string val)
        {
            GetDb().HashSet(listKey, key, val);
            return RedirectToAction("Index");
        }
        public IDatabase GetDb()
        {
            return _redisService.GetDb(1);
        }
    }
}
