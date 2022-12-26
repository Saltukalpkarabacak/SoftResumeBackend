using Application.Features.UserProgramingTechnologies.Dtos;
using Application.Features.UserSocialMediaAddresses.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProgramingTechnologies.Models
{
    public class UserProgramingTechnologyListModel:BasePageableModel
    {
        public IList<UserProgramingTechnologyListDto> Items { get; set; }
    }
}
