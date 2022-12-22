using Application.Services;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    /// <summary>
    /// Programlama dili teknolojileri için metotların bulunduğu repository sınıfıdır.
    /// </summary>
    public class ProgrammingLanguageTechnologyRepository : EfRepositoryBase<ProgrammingLanguageTechnology, BaseDbContext>, IProgrammingLanguageTechnologyRepository
    {
        public ProgrammingLanguageTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
