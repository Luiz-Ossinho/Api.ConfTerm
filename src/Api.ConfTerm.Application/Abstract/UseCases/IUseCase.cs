using System.Threading.Tasks;

namespace Api.ConfTerm.Application.Abstract.UseCases
{
    public interface IUseCase<in TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest data);
    }
}
