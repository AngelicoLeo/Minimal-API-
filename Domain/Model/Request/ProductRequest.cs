namespace CalendarApp.Domain.Model.Request;

public record ProductRequest(string Code, string Name, string Description, int CategoryId, decimal Price,List<string> Tags);
