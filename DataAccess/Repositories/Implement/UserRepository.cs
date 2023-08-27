using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(InterviewManagementContext context) : base(context)
        {

        }

        public User? GetByName(string name)
        {
            return dbSet.FirstOrDefault(u => u.FullName == name);
        }
    }
}
