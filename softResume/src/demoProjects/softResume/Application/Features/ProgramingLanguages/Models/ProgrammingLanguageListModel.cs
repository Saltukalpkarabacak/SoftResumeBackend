using Application.Features.ProgramingLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Models
{
    /// <summary>
    /// Programlama dili için geriye dönen sayfalanmış veri modeli
    /// </summary>
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
