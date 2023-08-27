using DataAccess.Models;

namespace DataAccess.Repositories.Implement
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
