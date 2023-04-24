using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dtos;
using WebApi.Repositories;

namespace WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly ProductRepository _productRepo;

    public ProductsController(ProductRepository productRepo)
    {
        _productRepo = productRepo;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productRepo.GetAllProductsAsync());
    }

    [HttpGet("{articleNumber}")]
    public async Task<IActionResult> Get(string articleNumber)
    {
        var product = await _productRepo.GetProductByIdAsync(articleNumber);
        if(product != null)
            return Ok(product);

        return NotFound();
    }

    [HttpGet("tag/{tagName}")]
    public async Task<IActionResult> GetByTag(string tagName)
    {
        return Ok(await _productRepo.GetAllProductsByTagAsync(tagName));
    }




    [HttpPost]
    public async Task<IActionResult> Create(ProductHttpRequest req)
    {
        if(ModelState.IsValid)
        {
            var product = await _productRepo.CreateProductAsync(req);
            if(product != null)
                return Created("", product);
        }

        return BadRequest();
    }
}


/*   

client -> server (request)
server -> client (response)


form -> api/database                UserHttpRequest

firstname
lastname
email
password


form/page <- api/database           UserHttpResponse

id
firstname
lastname
email


*/