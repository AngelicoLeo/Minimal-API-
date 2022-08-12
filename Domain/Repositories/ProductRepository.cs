using CalendarApp.Domain.Model;
using CalendarApp.Domain.Model.Request;

namespace CalendarApp.Domain.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Product CreateProduct(ProductRequest productReq)
    {
        Product product = _context.Products.Where(p => string.Equals(p.Name, productReq.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        var category = _context.Categories.Where(c => c.Id == productReq.CategoryId).FirstOrDefault();
        if(product is not null || category is null)
        {
            return null;
        }

        product = new Product()
        {
            Name = productReq.Name,
            CreatedOn = DateTime.Now,
            Description = productReq.Description,
            Price = productReq.Price,
            CategoryId = productReq.CategoryId,
            Tags = productReq.Tags
        };
        
        _context.Products.Add(product);

        return product;
    }

    public Product Get(Guid Id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(ProductRequest productReq)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Guid Id)
    {
        throw new NotImplementedException();
    }
}
