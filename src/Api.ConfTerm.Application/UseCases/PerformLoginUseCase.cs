using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Domain.ValueObjects;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class PerformLoginUseCase : IUseCase<LoginRequest>
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

        public async Task<ApplicationResponse> Handle(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            if (!Email.IsValid(request.Email))
                return response.BadRequest();

            var user = await _repository.GetByEmailAsync(request.Email, cancellationToken);

            if (!_hashingService.Compare(request.Password, user.Password, user.Salt))
                return response.BadRequest();

            var token = _tokenService.GenerateTokenForUser(user);

            return response.WithData(new { Token = token });
        }
    }
}
