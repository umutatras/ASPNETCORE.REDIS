using IDistributedCacheRedisApp.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace IDistributedCacheRedisApp.WEB.Controllers
{
    public class Productscontroller : Controller
    {
        private readonly IDistributedCache _cache;

        public Productscontroller(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1);
            Product product=new Product { Id = 1, Name="kalem",Price=100 };
            string jsonProduct=JsonConvert.SerializeObject(product);
            await _cache.SetStringAsync("product:1", jsonProduct,options);//complex type  kaydetmek istediğimiz verilerde seriliaze yaparız.

            //binary olarak kaydetme
            //Byte[] byteproduct=Encoding.UTF8.GetBytes(jsonProduct);
            //_cache.Set("product:1", byteproduct);
            //_cache.SetString("name", "UMUT", options);

            //await _cache.SetStringAsync("surname", "Atras", options);
            return View();
        }

        public IActionResult Show()
        {
            //byte olarak okuma
            //Byte[] byteproduct = _cache.Get("product:1");
            //string jsonproduct=Encoding.UTF8.GetString(byteproduct);


            //var name=_cache.GetString("name");
            //ViewBag.name = name;
            string jsonProduct = _cache.GetString("product:1");
            Product p= JsonConvert.DeserializeObject<Product>(jsonProduct)!;
            ViewBag.p= p;
            return View();

        }

        public IActionResult Remove()
        {
            _cache.Remove("name");
            return View();
        }
        public IActionResult ImageUrl()
        {
            byte[] resimbyte = _cache.Get("resim");
            return File(resimbyte,"image/jpg");
        }
        public IActionResult ImageCache()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/araba.jpg");
            byte[] imageByte=System.IO.File.ReadAllBytes(path);
            _cache.Set("resim", imageByte);
            
            return View();
        }
    }
}
