using Application.Features.OperationClaims.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Models
{
    /// <summary>
    /// Operasyon Claim için geriye dönen sayfalanmış veri modeli
    /// </summary>
    public class OperationClaimListModel : BasePageableModel
    {
        public IList<OperationClaimListDto> Items { get; set; }
    }
}
