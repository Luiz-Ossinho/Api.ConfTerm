using Api.ConfTerm.Domain.Entities.Abstract;
using System.Collections.Generic;

namespace Api.ConfTerm.Domain.Entities
{
    public class Housing : IdentifiableEntity
    {
        public string Identification { get; set; }

        //EF Core Property
        public virtual User Owner { get; set; }
        public virtual ICollection<AnimalProduction> AnimalProductions { get; set; } = new List<AnimalProduction>();

    }
}
