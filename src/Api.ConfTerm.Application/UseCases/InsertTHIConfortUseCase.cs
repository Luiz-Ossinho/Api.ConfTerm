using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using System.Net;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.UseCases
{
    public class InsertTHIConfortUseCase : IInsertTHIConfortUseCase
    {
        private readonly IRepository<TemperatureHumidityIndexConfort> _thiRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertTHIConfortUseCase(IRepository<TemperatureHumidityIndexConfort> thiRepository, IUnitOfWork unitOfWork, IRepository<Species> speciesRepository)
        {
            _thiRepository = thiRepository;
            _unitOfWork = unitOfWork;
            _speciesRepository = speciesRepository;
        }
        public async Task<ApplicationResponse> HandleAsync(InsertTHIConfortRequest data)
        {
            var response = ApplicationResponse.OfNone();

            // TODO aplicar validacoes
            //response.CheckFor()
            //

            var species = await _speciesRepository.GetByIdAsync(data.SpeciesId);

            if (species == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(data.SpeciesId)));

            var confort = new TemperatureHumidityIndexConfort
            {
                Level = data.Level,
                MaximunAge = data.MaximunAge,
                MinimunAge = data.MinimunAge,
                MaximunTemperatureHumidityIndex = data.MaximunTHI,
                MinimunTemperatureHumidityIndex = data.MinimunTHI,
                Species = species
            };
            await _thiRepository.InsertAsync(confort);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created);
        }
    }
}
