using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implement
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
