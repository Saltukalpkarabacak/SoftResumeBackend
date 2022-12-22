using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Dtos
{
    /// <summary>
    /// Operasyon claim oluşturma dto
    /// </summary>
    public class CreatedOperationClaimDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
