using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Dtos
{
    /// <summary>
    /// Oluşturulan Programlama dilini döndüren dto sınıfı.
    /// </summary>
    public class CreatedProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
