using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7080/api/products");

            return View(result);
        }
    }
}