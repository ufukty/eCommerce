using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using eCommerce.Models;
using Microsoft.AspNet.Identity;

namespace eCommerce.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        CartItemContext dbCart = new CartItemContext();
        ProductContext dbProd = new ProductContext();

        public ActionResult Index()
        {
            VMCartIndex viewModel = new VMCartIndex(dbCart, dbProd, User.Identity.GetUserId());
            return View(viewModel);
        }

        public ActionResult Remove(int itemID)
        {
            var cartItem = dbCart.CartItems.Find(itemID);
            if (cartItem != null)
            {
                dbCart.CartItems.Remove(cartItem);
                dbCart.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}