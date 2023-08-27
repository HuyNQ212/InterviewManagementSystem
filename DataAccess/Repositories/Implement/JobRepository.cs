﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implement
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(InterviewManagementContext context) : base(context)
        {
        }
    }
}
