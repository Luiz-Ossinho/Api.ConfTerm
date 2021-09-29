using System.Text.Json.Serialization;

namespace Api.ConfTerm.Application.Objects
{
    public class ApplicationError
    {
        private ApplicationError() { }

        [JsonIgnore]
        private string Error { get; init; }
        [JsonIgnore]
        private string FieldName { get; init; }
        public string Value { get => FieldName != default ? $"Error in the field {FieldName}: Value {Error}" : Error; }

        public static ApplicationError Of(string error)
            => new() { Error = error };

        public static ApplicationError OfNotFound(string objectName)
            => new() { Error = $"{objectName} was Not Found" };

        public static ApplicationError Of(string error, string fieldName)
            => new() { Error = error, FieldName = fieldName };
    };
}
