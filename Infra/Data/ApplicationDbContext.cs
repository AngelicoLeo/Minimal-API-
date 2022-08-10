using CalendarApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
//classe configuradora do banco
public class ApplicationDbContext : DbContext
{
    //irá mapear as tabelas do banco 
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //configura as migrations
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(255).IsRequired(false);
        builder.Entity<Product>()
            .Property(p => p.Name).IsRequired();        
        builder.Entity<Category>()
            .Property(c => c.Name).IsRequired();

        //altera o nome da tabela para Categories ao inves da classe Category no singular
        builder.Entity<Category>().ToTable("Categories");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer();
    // PARA APLICAR O MIGRATION dotnet ef database update


    // aplica essas configurações gerais evitando repetir configurações
    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }

}
