using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    /// <summary>
    /// Güncellenecek Kullanıcının Sosyal Medya Adreslerini döndüren dto sınıfı.
    /// </summary>
    public class UpdatedUserSocialMediaAddressDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
    }
}
