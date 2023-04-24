using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {

            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7080/api/products");

            return View(result);

        }
        public async Task<IActionResult> Details(string articleNumber)
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<ProductModel>($"https://localhost:7080/api/products/{articleNumber}");
            return View(result);
        }
    }
}
