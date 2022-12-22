using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Dtos
{
    /// <summary>
    /// Güncellenecek Programlama dilinin döndüren dto sınıfı.
    /// </summary>
    public class UpdatedProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
