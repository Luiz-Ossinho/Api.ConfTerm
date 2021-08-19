using Api.ConfTerm.Domain.Entities.Abstract;
using Api.ConfTerm.Domain.ValueObjects;
using System.Collections.Generic;

namespace Api.ConfTerm.Domain.Entities
{
    public class User : IdentifiableEntity
    {
        public string Name { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public UserType Type { get; set; }
        public Email Email { get; set; }

        //EF Core Property
        public virtual ICollection<Housing> Housings { get; set; } = new List<Housing>();
    }
}
