using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dtos;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        private readonly ContactFormRepository _contactFormRepository;

        public ContactFormController(ContactFormRepository contactFormRepository)
        {
            _contactFormRepository = contactFormRepository;
        }
        [Route("contacts")]
        [HttpPost]
        public async Task<IActionResult> SaveMessageAsync(ContactHttpRequest req)
        {
            if(ModelState.IsValid)
            {
                var message = await _contactFormRepository.SaveContactMessage(req);

                if(message != null)
                {
                    return Created("", message);
                }

            }

            return BadRequest();
        }
    }
}
