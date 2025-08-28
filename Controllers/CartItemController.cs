using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace eCommerce.Controllers
{
    public class CartItemController : Controller
    {
        CartItemContext db = new CartItemContext();

        // GET: CartItem
        public IActionResult Index()
        {
            return View(db.CartItems.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CartItem cartItem)
        {
            if (ModelState.IsValid)
            {
                db.CartItems.Add(cartItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartItem);
        }
    }
}