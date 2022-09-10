using Core.Persistence.Paging;
using Devs.Application.Features.programmingLanguages.Dtos.ProgrammingLanguageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.programmingLanguages.Models
{
    public class ProgramminLanguageEntityListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageEntityListDto> Items { get; set; }
    }
}
