
using CalendarApp.Domain.Model;
using CalendarApp.Domain.Model.Request;

namespace CalendarApp.Domain.Repositories;

public interface IProductRepository
{
    Product Get(Guid Id);
    IEnumerable<Product> GetAll();
    Product CreateProduct(ProductRequest product);
    void UpdateProduct(ProductRequest product);
    void DeleteProduct(Guid Id);
}
