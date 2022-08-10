namespace CalendarApp.Domain.Model;

public class Product: Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
}
