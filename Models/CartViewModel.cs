using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace eCommerce.Models
{
    public class VMCartIndex
    {
        public CartItemContext dbCart;
        public ProductContext dbProd;

        public List<Product> products;
        public List<CartItem> cartItems;

        public VMCartIndex(CartItemContext dbCart, ProductContext dbProd, string userID)
        {
            this.dbCart = dbCart;
            this.dbProd = dbProd;
            var query = "SELECT * FROM dbo.CartItems WHERE [UserID] = '" + userID + "'";
            this.cartItems = this.dbCart.CartItems.SqlQuery(query).ToList();
        }

        public Product ProductDetails(CartItem cartItem)
        {
            return dbProd.Products.Find(cartItem.ProductID);
        }
    }
}