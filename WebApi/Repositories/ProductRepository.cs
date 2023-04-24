using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Repositories;

public class ProductRepository
{

    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    //Hämtar produkt beroende på artikelnummer
    public async Task<ProductHttpResponse> GetProductByIdAsync(string articleNumber)
    {
        var item = await _context.Products.FindAsync(articleNumber);
        return item!;
    }

    //Hämtar alla produkter
    public async Task<IEnumerable<ProductHttpResponse>> GetAllProductsAsync()
    {
        var items = await _context.Products.ToListAsync();
        var products = new List<ProductHttpResponse>();

        foreach(var item in items)
            products.Add(item);

        return products;
    }

    //Hämtar alla produkter med en viss tag
    public async Task<IEnumerable<ProductHttpResponse>> GetAllProductsByTagAsync(string tag)
    {
        var items = await _context.Products.Where(x => x.Tag == tag).ToListAsync();
        var products = new List<ProductHttpResponse>();

        foreach(var item in items)
            products.Add(item);

        return products;
    }
    //Skapar produkter
    public async Task<ProductHttpResponse> CreateProductAsync(ProductEntity entity)
    {
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
