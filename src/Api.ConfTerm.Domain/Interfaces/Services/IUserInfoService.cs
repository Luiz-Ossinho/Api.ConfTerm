using Api.ConfTerm.Domain.Enums;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Domain.Interfaces.Services
{
    public interface IUserInfoService
    {
        public string Name { get; }
        public Email Email { get; }
        public UserType Type { get; }
    }
}
