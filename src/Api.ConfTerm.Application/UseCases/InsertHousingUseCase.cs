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
    public class InsertHousingUseCase : IInsertHousingUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Housing> _housingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InsertHousingUseCase(IUserRepository userRepository, IRepository<Housing> housingRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _housingRepository = housingRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationResponse> HandleAsync(InsertHousingRequest data)
        {
            var response = ApplicationResponse.OfNone();

            response.CheckFor(!string.IsNullOrEmpty(data.Identificantion), ApplicationError.ArgumentWasInvalid(nameof(data.Identificantion)))
                .CheckFor(Email.IsValid(data.UserMail), ApplicationError.ArgumentWasInvalid(nameof(data.UserMail)));

            if (!response.Success)
                return response;

            var user = await _userRepository.GetByEmailAsync(data.UserMail);

            if (user == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(data.UserMail)));

            var hosuing = new Housing
            {
                Identification = data.Identificantion,
                Owner = user
            };

            await _housingRepository.InsertAsync(hosuing);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created);
        }
    }
}
