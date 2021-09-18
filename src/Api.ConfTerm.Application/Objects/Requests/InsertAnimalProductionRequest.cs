using Api.ConfTerm.Application.Abstract;
using System;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertAnimalProductionRequest(int HousingId, int SpeciesId, DateTime BirthDay,
        DateTime MonitoringStart, DateTime MonitoringEnd, string Equipament) : ApplicationRequest;
}
