using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Domain.Entities.Abstract
{
    public abstract class Confort : IdentifiableEntity
    {
        public Species Species { get; set; }
        public int MinimunAge { get; set; }
        public int MaximunAge { get; set; }
        public ConfortLevel Level { get; set; }
    }
}
