using CalendarApp.Domain.Model;

namespace CalendarApp.Domain.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public User Get(string username, string password)
    {
        //tratar password e buscar no banco

        return _context.Users.FirstOrDefault(x =>
                                string.Equals(x.UserName, username, StringComparison.CurrentCultureIgnoreCase) //ignora o case sensitive..
                                && x.Password == password);
    }
}
