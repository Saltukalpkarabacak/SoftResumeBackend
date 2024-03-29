﻿using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserProgramingTechnologyRepository : IAsyncRepository<UserProgramingTechnolgy>, IRepository<UserProgramingTechnolgy>
    {
    }
}
