using CalendarApp.Domain.Model;

namespace CalendarApp.Domain.Repositories;

public interface IUserRepository
{
    User Get(string username, string password);
}
