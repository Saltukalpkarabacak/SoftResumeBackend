using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// Kullanıclar için metotların imzalarını tutar.
    /// </summary>
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {

    }
}
