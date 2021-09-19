using System.Collections.Generic;
using System.Linq;

namespace Api.ConfTerm.Domain.ValueObjects
{
    public class UserType
    {
        public static UserType Administrator { get; } = new UserType { Name = "Administrator", Id = 1 };
        public static UserType Normal { get; } = new UserType { Name = "Normal", Id = 2 };
        public static ICollection<UserType> ValidRoles { get; } = new List<UserType> { Administrator, Normal };
        public string Name { get; private set; }
        public int Id { get; private set; }
        public static UserType GetValid(int id) => ValidRoles.SingleOrDefault(r => r.Id == id);
        public static UserType GetValid(string name) => ValidRoles.SingleOrDefault(r => r.Name == name);
    }
}
