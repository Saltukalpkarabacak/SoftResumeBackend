using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Models
{
    /// <summary>
    /// Programlama dili teknolojileri için kullanılan model
    /// </summary>
    public class ProgrammingLanguageTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageTechnologyListDto> Items { get; set; }
    }
}
