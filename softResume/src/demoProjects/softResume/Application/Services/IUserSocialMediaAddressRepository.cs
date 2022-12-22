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
    /// Kullanıcı sosyal medya adresi için kullanılan repository imzasıdır.
    /// </summary>
    public interface IUserSocialMediaAddressRepository : IAsyncRepository<UserSocialMediaAddress>, IRepository<UserSocialMediaAddress>
    {
    }
}
