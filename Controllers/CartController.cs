using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using eCommerce.Models;

namespace eCommerce.Controllers;

[Authorize]
public class CartController : Controller
{
    CartItemContext dbCart = new CartItemContext();
    ProductContext dbProd = new ProductContext();

    public IActionResult Index()
    {
        VMCartIndex viewModel = new VMCartIndex(dbCart, dbProd, User.Identity.GetUserId());
        return View(viewModel);
    }

    public IActionResult Remove(int itemID)
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
