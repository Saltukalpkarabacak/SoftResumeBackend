using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Programlama dili teknolojileri için metotların imzalarını tutar.
    /// </summary>
    public interface IProgrammingLanguageTechnologyRepository : IAsyncRepository<ProgrammingLanguageTechnology>, IRepository<ProgrammingLanguageTechnology>
    {

    }
}
