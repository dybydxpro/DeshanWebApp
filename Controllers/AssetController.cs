﻿using DeshanWebApp.Models;
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
            return RedirectToAction("Index");
        }

        public IActionResult TransferAction()
        {
            return View();
        }

        public IActionResult TransferAssets(TransferDetails td)
        {
            IEnumerable<Cart> Cartobj = _database.Carts.ToList();
            if (Cartobj == null)
            {
                return NotFound();
            }

            //var lastInput = _database.Transfers.OrderByDescending(u => u.TID).FirstOrDefault();
            //var nextTID = int.Parse(lastInput.TID) + 1;
            int nextTID = MaxTID();
            foreach (var item in Cartobj)
            {
                int tempID = item.Id;
                var data = new Transfer();
                data.CartID = item.AssetID;
                data.Name = item.Name;
                data.ISBN = item.ISBN;
                data.Location = td.Location;
                data.TID = nextTID;
                _database.Transfers.Add(data);
                _database.SaveChanges();

                Delete(tempID);
            }
            return RedirectToAction("Index");
        }

        public void Delete(int? id)
        {
            var obj = _database.Carts.Find(id);
            _database.Carts.Remove(obj);
            _database.SaveChanges();
        }

        public int MaxTID()
        {
            var maxId = (_database.Transfers.Select(q => (int?)q.TID).Max() ?? 0) + 1;
            return maxId;
        }
    }
}
