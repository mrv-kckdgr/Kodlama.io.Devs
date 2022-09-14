using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class TechnologyEntity : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguageEntity? ProgrammingLanguage { get; set; }

        public TechnologyEntity()
        {
        }

        public TechnologyEntity(int id, int programmingLanguageId, string name) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
