namespace Api.ConfTerm.Application.Objects
{
    public class ApplicationError
    {
        public string Value { get; init; }
        public static ApplicationError WasNullForArgument(string @object, string argument) {
            return new ApplicationError { Value = $"{@object} was null for the {argument} specified" };
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
