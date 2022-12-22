using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    /// <summary>
    /// Getirilecek Programlama dili teknolojisini döndüren dto sınıfı.
    /// </summary>
    public class ProgrammingLanguageTechnologyGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
