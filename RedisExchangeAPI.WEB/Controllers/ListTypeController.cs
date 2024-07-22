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
            List<string> namesList = new List<string>();

            var db = GetDb();
            if (db.KeyExists(listKey))
            {
                foreach (var item in db.ListRange(listKey).ToList())
                {
                    namesList.Add(item.ToString());
                };
            }
            return View(namesList);
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            GetDb().ListRightPush(listKey, name);
            return View();
        }        
        public IActionResult DeleteItem(string name)
        {
            GetDb().ListRemove(listKey, name);
            return RedirectToAction("Index");
        }
        private IDatabase GetDb()
        {
            return _redisService.GetDb(1);
        }
    }
}
