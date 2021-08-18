using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Domain.ValueObjects;
using System.Net;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertUserUseCase : IInsertUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IHashingService _hashingService;
        private readonly IUnitOfWork _unitOfWork;
        public InsertUserUseCase(IUserRepository repository, IHashingService hashingService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _hashingService = hashingService;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse> HandleAsync(InsertUserRequest data)
        {
            var response = ApplicationResponse.OfNone();

            response.CheckFor(Email.IsValid(data.Email), ApplicationError.ArgumentWasInvalid(nameof(data.Email)))
                .CheckFor(!string.IsNullOrEmpty(data.Password), ApplicationError.ArgumentWasInvalid(nameof(data.Password)))
                .CheckFor(!string.IsNullOrEmpty(data.Name), ApplicationError.ArgumentWasInvalid(nameof(data.Name)));

            if (!response.Success)
                return response;

            var salt = _hashingService.GenerateSalt();
            var password = _hashingService.GenerateHash(data.Password, salt);

            var user = new User()
            {
                Email = data.Email,
                Name = data.Name,
                Type = data.Type,
                Salt = salt,
                Password = password
            };

            await _repository.InsertAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created);
        }
    }
}
