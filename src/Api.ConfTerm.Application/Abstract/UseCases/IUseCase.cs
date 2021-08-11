namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IUseCase<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest data);
    }
}
