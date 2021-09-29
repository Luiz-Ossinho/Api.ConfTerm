using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertHousingUseCase : IUseCase<InsertHousingRequest>
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

        public async Task<ApplicationResponse> Handle(InsertHousingRequest request, CancellationToken cancellationToken = default)
        {
            var response = ApplicationResponse.OfOk();

            var user = await _userRepository.GetByEmailAsync(request.UserMail, cancellationToken);

            if (user == default)
                return response.WithNotFound(ApplicationError.OfNotFound(nameof(user)));

            int housingId = await PersistHousing(request, user, cancellationToken);

            return response.WithCreated(new { HousingId = housingId });
        }

        private async Task<int> PersistHousing(InsertHousingRequest request, User user, CancellationToken cancellationToken)
        {
            var hosuing = new Housing
            {
                Identification = request.Identificantion,
                Owner = user
            };

            await _housingRepository.InsertAsync(hosuing, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var housingId = hosuing.Id;
            return housingId;
        }
    }
}
