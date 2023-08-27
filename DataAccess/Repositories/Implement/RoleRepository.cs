using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implement
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
