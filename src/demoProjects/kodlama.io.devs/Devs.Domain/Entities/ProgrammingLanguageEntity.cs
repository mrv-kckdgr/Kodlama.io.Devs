using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
    public class ProgrammingLanguageEntity : Entity
    {
        public string Name { get; set; }

        public ProgrammingLanguageEntity()
        {
        }

        public ProgrammingLanguageEntity(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
