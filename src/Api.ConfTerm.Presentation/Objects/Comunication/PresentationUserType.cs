using System.Runtime.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication
{
    public enum PresentationUserType
    {
        [EnumMember(Value = "Administrador")] Administrator,
        [EnumMember(Value = "Normal")] Normal
    }
}
