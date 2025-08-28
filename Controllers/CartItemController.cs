using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CartItemController : Controller
    {
        CartItemContext db = new CartItemContext();

        // GET: CartItem
        public ActionResult Index()
        {
            return View(db.CartItems.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CartItem cartItem)
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