using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = _cartItems.Find(item => item.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = quantity,
                    UnitPrice = product.Price
                });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cartItems.Find(i => i.ProductId == productId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = _cartItems.Find(i => i.ProductId == productId);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(item => item.Quantity* item.UnitPrice);
        }
    }
}
