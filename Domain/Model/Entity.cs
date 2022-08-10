namespace CalendarApp.Domain.Model;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    //quem gera é o proprio codigo, sem ser o banco a gerar o Id
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime LastEdit { get; set; }
}
