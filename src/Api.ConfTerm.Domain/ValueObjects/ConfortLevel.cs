using System.Collections.Generic;
using System.Linq;

namespace Api.ConfTerm.Domain.ValueObjects
{
    public class ConfortLevel
    {
        public static ConfortLevel Confortable { get; } = new ConfortLevel { Name = "Confortable", Id = 0 };
        public static ConfortLevel LightStress { get; } = new ConfortLevel { Name = "LightStress", Id = 1 };
        public static ConfortLevel DangerousStress { get; } = new ConfortLevel { Name = "DangerousStress", Id = 2 };
        public static ConfortLevel EmergencyStress { get; } = new ConfortLevel { Name = "EmergencyStress", Id = 3 };
        public static ICollection<ConfortLevel> ValidLevels { get; } = new List<ConfortLevel> { Confortable, LightStress, DangerousStress, EmergencyStress };
        public string Name { get; private set; }
        public int Id { get; private set; }
        public static ConfortLevel GetValid(int id) => ValidLevels.SingleOrDefault(r => r.Id == id);
        public static ConfortLevel GetValid(string name) => ValidLevels.SingleOrDefault(r => r.Name == name);
    }
}
