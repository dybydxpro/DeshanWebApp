using DeshanWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeshanWebApp.Controllers
{
    public class AssetController : Controller
    {
        private readonly AppDatabaseContexts _database;
        public AssetController(AppDatabaseContexts database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            IEnumerable<Asset> data = _database.Assets.ToList();
            return View(data);
        }

        public IActionResult Cart()
        {
            IEnumerable<Cart> data = _database.Carts.ToList();
            return View(data);
        }

        public IActionResult SetToCart(int? id)
        {
            var data = _database.Assets.Find(id);
            var obj = new Cart();
            obj.AssetID = data.Id;
            obj.Name = data.Name;
            obj.ISBN = data.ISBN;
            _database.Carts.Add(obj);
            _database.SaveChanges();
            return RedirectToAction("Cart");
        }
    }
}
