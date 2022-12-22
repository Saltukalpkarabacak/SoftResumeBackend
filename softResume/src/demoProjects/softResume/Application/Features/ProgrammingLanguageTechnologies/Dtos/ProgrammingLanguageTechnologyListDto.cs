using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    /// <summary>
    /// Getirilecek Tüm Programlama dili teknolojisini döndüren dto sınıfı.
    /// </summary>
    public class ProgrammingLanguageTechnologyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
