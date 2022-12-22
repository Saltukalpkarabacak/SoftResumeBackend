using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Dtos
{
    /// <summary>
    /// İlgili Kullanıcının Sosyal Medya Adreslerini döndüren dto sınıfı.
    /// </summary>
    public class UserSocialMediaAddressGetByIdDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

