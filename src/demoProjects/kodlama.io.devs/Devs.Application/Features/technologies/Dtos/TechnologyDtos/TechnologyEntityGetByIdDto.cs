using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.technologies.Dtos.TechnologyDtos
{
    public class TechnologyEntityGetByIdDto
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }        
        public string Name { get; set; }
    }
}
