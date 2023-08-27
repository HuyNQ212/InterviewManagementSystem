using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByName(string name);
    }
}
