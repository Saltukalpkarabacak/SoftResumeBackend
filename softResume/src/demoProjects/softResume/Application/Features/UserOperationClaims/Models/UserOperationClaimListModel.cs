﻿using Application.Features.UserOperationClaims.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Models
{
    /// <summary>
    /// Kullanıcı Operasyon Claim için geriye dönen sayfalanmış veri modeli
    /// </summary>
    public class UserOperationClaimListModel : BasePageableModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
