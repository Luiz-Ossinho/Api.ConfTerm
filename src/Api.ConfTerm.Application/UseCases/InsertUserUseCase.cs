﻿using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Domain.ValueObjects;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertUserUseCase : IUseCase<InsertUserRequest>
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

        public async Task<ApplicationResponse> Handle(InsertUserRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfNone();

            response.CheckFor(Email.IsValid(request.Email), ApplicationError.ArgumentWasInvalid(nameof(request.Email)))
                .CheckFor(!string.IsNullOrEmpty(request.Password), ApplicationError.ArgumentWasInvalid(nameof(request.Password)))
                .CheckFor(!string.IsNullOrEmpty(request.Name), ApplicationError.ArgumentWasInvalid(nameof(request.Name)));

            if (!response.Success)
                return response;

            await PersistUser(request, cancellationToken);

            return response.WithCode(HttpStatusCode.Created);
        }

        private async Task PersistUser(InsertUserRequest request, CancellationToken cancellationToken = default)
        {
            var salt = _hashingService.GenerateSalt();
            var password = _hashingService.GenerateHash(request.Password, salt);

            var user = new User()
            {
                Email = request.Email,
                Name = request.Name,
                Type = request.Type,
                Salt = salt,
                Password = password
            };

            await _repository.InsertAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
