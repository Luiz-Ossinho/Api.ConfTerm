using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class PerformLoginUseCase : IUseCase<PerformLoginRequest>
    {
        private readonly IUserRepository _repository;
        private readonly IHashingService _hashingService;
        private readonly ITokenService _tokenService;
        public PerformLoginUseCase(IUserRepository repository, IHashingService hashingService, ITokenService tokenService)
        {
            _hashingService = hashingService;
            _repository = repository;
            _tokenService = tokenService;
        }

        public async Task<ApplicationResponse> Handle(PerformLoginRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfOk();

            var user = await _repository.GetByEmailAsync(request.Email, cancellationToken);

            if (!_hashingService.Compare(request.Password, user.Password, user.Salt))
                return response.WithBadRequest(ApplicationError.Of("Password doesnt match"));

            var token = _tokenService.GenerateTokenForUser(user);

            return response.WithData(new { Token = token });
        }
    }
}
