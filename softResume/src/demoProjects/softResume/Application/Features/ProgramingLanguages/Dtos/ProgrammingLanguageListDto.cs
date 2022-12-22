using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Dtos
{
    /// <summary>
    /// Tüm Programlama dilinin döndüren dto sınıfı.
    /// </summary>
    public class ProgrammingLanguageListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProgrammingLanguageTechnologyListDto> ProgrammingTechnologies { get; set; }
    }
}
