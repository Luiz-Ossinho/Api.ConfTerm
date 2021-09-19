using System.Runtime.Serialization;

namespace Api.ConfTerm.Presentation.Objects.Comunication
{
    public enum PresentationConfortLevel
    {
        [EnumMember(Value = "Confortavel")] Confortable,
        [EnumMember(Value = "StressLeve")] LightStress,
        [EnumMember(Value = "StressModerado")] DangerousStress,
        [EnumMember(Value = "StressEmergencial")] EmergencyStress
    }
}
