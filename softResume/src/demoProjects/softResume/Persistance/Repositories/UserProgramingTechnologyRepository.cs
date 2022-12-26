using Application.Services;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserProgramingTechnologyRepository : EfRepositoryBase<UserProgramingTechnolgy, BaseDbContext>, IUserProgramingTechnologyRepository
    {
        public UserProgramingTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
