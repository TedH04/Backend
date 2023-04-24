using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Index(ContactFormModel contactModel)
        {
            if(ModelState.IsValid)
            {
                using var http = new HttpClient();

                var result = await http.PostAsJsonAsync("https://localhost:7080/api/contactform/contacts", contactModel);
                if(result.IsSuccessStatusCode)
                {
                    ModelState.Clear();
                    return RedirectToAction(nameof(Index));
                }

                return BadRequest(result);
            }

            return View(contactModel);
        }

    }
}