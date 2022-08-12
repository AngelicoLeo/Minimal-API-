namespace CalendarApp.Domain.Model;

public abstract class Entity
{    
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastEdit { get; set; }
}
