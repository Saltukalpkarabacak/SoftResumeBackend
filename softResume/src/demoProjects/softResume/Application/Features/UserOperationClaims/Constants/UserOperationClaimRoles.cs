using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Constants
{
    /// <summary>
    /// Kullanıcı Operasyon claimleri için rol tanımları
    /// </summary>
    public class UserOperationClaimRoles
    {
        public const string UserOperationClaimAdmin = "UserOperationClaim.Admin";
        public const string Admin = "Admin";
        public const string UserOperationClaimCreate = "UserOperationClaim.Create";
        public const string UserOperationClaimDelete = "UserOperationClaim.Delete";
        public const string UserOperationClaimUpdate = "UserOperationClaim.Update";

        public const string UserOperationClaimRead = "UserOperationClaim.Read";
    }
}
