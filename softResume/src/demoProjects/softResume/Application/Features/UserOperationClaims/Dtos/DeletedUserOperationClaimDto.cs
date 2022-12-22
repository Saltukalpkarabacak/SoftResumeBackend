using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Dtos
{
    /// <summary>
    /// Kullanıcı Operasyon claim silme dto
    /// </summary>
    public class DeletedUserOperationClaimDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
