using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using eCommerce.Models;

namespace eCommerce.Controllers;

public class ProductController(Data.AppDbContext db) : Controller
{
    private readonly Data.AppDbContext _db = db;
    ProductContext db = new Models.ProductContext();
    CartItemContext dbCart = new Models.CartItemContext();

    // GET: Product
    public IActionResult List(string gender, string category, string size)
    {
        FilterList filter = new FilterList(gender, category, size);
        ListViewModel viewModel = new ListViewModel(filter, db);

        return View(viewModel);
    }

    public IActionResult Detail(int productID)
    {
        return View(db.Products.Find(productID));
    }

    [Authorize]
    public IActionResult AddCart(int productID, string size, int quantity)
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