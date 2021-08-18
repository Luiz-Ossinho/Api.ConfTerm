using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class PerformLoginUseCase : IPerformLoginUseCase
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

        public async Task<ApplicationResponse> HandleAsync(LoginRequest data)
        {
            var response = ApplicationResponse.OfNone();

            if (!Email.IsValid(data.Email))
                return response.BadRequest();

            var user = await _repository.GetByEmailAsync(data.Email);

            if (!_hashingService.Compare(data.Password, user.Password, user.Salt))
                return response.BadRequest();

            var token = _tokenService.GenerateTokenForUser(user);

            return response.WithData(new { Token = token });
        }
    }
}
