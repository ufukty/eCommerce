using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Controllers
{
    [Authorize]
    public class ProductManagerController : Controller
    {
        ProductContext db = new ProductContext();




        public IActionResult Index()
        {
            return View(db.Products.ToList());
        }




        public IActionResult Edit(int ID)
        {
            Product product = db.Products.Find(ID);
            return View(product);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(int? ID)
        {
            var productToUpdate = db.Products.Find(ID);
            if (TryUpdateModel(productToUpdate, "", new string[] { "Name", "ImagePath", "Gender", "Category", "QuantityXS", "QuantityS", "QuantityM", "QuantityL", "QuantityXL", "Price", "DiscountedPrice" }))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productToUpdate);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }




        public IActionResult Delete(int? ID)
        {
            var productToDelete = db.Products.Find(ID);
            db.Products.Remove(productToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}