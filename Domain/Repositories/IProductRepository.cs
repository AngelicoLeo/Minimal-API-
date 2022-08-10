using CalendarApp.Domain.Model;

namespace CalendarApp.Domain.Repositories;

public interface IProductRepository
{
    Product Get(Guid Id);
    IEnumerable<Product> GetAll();
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Guid Id);
}
