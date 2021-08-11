namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public interface IPresentationRequest<out TApplicationRequest>
    {
        public abstract TApplicationRequest ToApplicationRequest();
    }
}
