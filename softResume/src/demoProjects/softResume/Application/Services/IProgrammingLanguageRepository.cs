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
    /// Programlama dilleri için metotların imzalarını tutar.
    /// </summary>
    public interface IProgrammingLanguageRepository : IAsyncRepository<ProgrammingLanguage>, IRepository<ProgrammingLanguage>
    {

    }
}
