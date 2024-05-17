using ShoppingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Services
{
    public class ProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>("/api/Products/all");
            return response ?? new List<Product>();
        }

        public async Task<List<Product>> GetProductsAsync(string searchQuery = "")
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>($"/api/Products?search={Uri.EscapeDataString(searchQuery)}");
            return response ?? new List<Product>();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetFromJsonAsync<Product>($"/api/Products/{productId}");
            return response ?? new Product();
        }
    }
}
