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
    public class InsertBGTHIConfortUseCase : IInsertBGTHIConfortUseCase
    {
        private readonly IRepository<BlackGlobeTemparuteHumidityIndexConfort> _bgthiRepository;
        private readonly IRepository<Species> _speciesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertBGTHIConfortUseCase(IRepository<BlackGlobeTemparuteHumidityIndexConfort> bgthiRepository,
            IUnitOfWork unitOfWork, IRepository<Species> speciesRepository)
        {
            _bgthiRepository = bgthiRepository;
            _unitOfWork = unitOfWork;
            _speciesRepository = speciesRepository;
        }
        public async Task<ApplicationResponse> HandleAsync(InsertBGTHIConfortRequest data)
        {
            var response = ApplicationResponse.OfNone();

            // TODO aplicar validacoes
            //response.CheckFor()
            //

            var species = await _speciesRepository.GetByIdAsync(data.SpeciesId);

            if (species == null)
                return response.BadRequest().WithError(ApplicationError.WasNullForArgument("User", nameof(data.SpeciesId)));

            var confort = new BlackGlobeTemparuteHumidityIndexConfort
            {
                Level = data.Level,
                MaximunAge = data.MaximunAge,
                MinimunAge = data.MinimunAge,
                Species = species,
                MaximunBlackGlobeTemperatureHumidityIndex = data.MaximunBGTHI,
                MinimunBlackGlobeTemperatureHumidityIndex = data.MinimunBGTHI
            };

            await _bgthiRepository.InsertAsync(confort);
            await _unitOfWork.SaveChangesAsync();

            return response.WithCode(HttpStatusCode.Created);
        }
    }
}
