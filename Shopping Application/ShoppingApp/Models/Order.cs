using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Shipping Address is required")]
        public string ShippingAddress { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal TotalPrice { get; set; }
        // Payment Information
        [Required(ErrorMessage = "Credit card number is required")]
        [CreditCard(ErrorMessage = "Invalid credit card number")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Expiration date is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "Invalid expiration date")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [RegularExpression(@"^[0-9]{3,4}$", ErrorMessage = "Invalid CVV")]
        public string CVV { get; set; }
    }
}
