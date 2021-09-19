using Api.ConfTerm.Application.Objects.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertTHIConfortRequest(int SpeciesId, int MinimunAge, int MaximunAge, float MinimunTHI, float MaximunTHI, ConfortLevel Level) : IApplicationRequest;
}
