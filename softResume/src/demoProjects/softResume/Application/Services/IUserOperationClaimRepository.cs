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
    /// Kullanıcı için işlem yetkilerini yöneten metotların imzasını tanımlar.
    /// </summary>
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {

    }
}
