using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Models
{
    /// <summary>
    /// Kullanıcı Sosyal Medya Adresi için kullanılan model
    /// </summary>
    public class UserSocialMediaAddressListModel : BasePageableModel
    {
        public IList<UserSocialMediaAddressListDto> Items { get; set; }
    }
}
