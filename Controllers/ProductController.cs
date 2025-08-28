using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using Microsoft.AspNet.Identity;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        ProductContext db = new ProductContext();
        CartItemContext dbCart = new CartItemContext();

        // GET: Product
        public ViewResult List(string gender, string category, string size)
        {
            FilterList filter = new FilterList(gender, category, size);
            ListViewModel viewModel = new ListViewModel(filter, db);

            return View(viewModel);
        }

        public ViewResult Detail(int productID)
        {

            return View(db.Products.Find(productID));
        }

        [Authorize]
        public ActionResult AddCart(int productID, string size, int quantity)
        {
            var query = "SELECT * FROM dbo.CartItems WHERE [UserID] = '" + User.Identity.GetUserId() + "' AND [ProductID] = " + productID + " AND [ProductSize] = '" + size + "'";
            var result = dbCart.CartItems.SqlQuery(query).ToList();

            if (result.Count() > 0)
            {
                CartItem itemToUpdate = dbCart.CartItems.Find(result[0].ID);
                itemToUpdate.Quantity += quantity;
                dbCart.SaveChanges();
            }
            else
            {
                CartItem itemToAdd = new CartItem
                {
                    ProductID = productID,
                    UserID = User.Identity.GetUserId(),
                    Quantity = quantity,
                    ProductSize = size
                };
                dbCart.CartItems.Add(itemToAdd);
                dbCart.SaveChanges();
            }


            return RedirectToAction("Detail", new { productID });
        }
    }
}