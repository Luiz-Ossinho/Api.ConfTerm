using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertBGTHIConfortRequest(int SpeciesId, int MinimunAge, int MaximunAge, float MinimunBGTHI, float MaximunBGTHI, ConfortLevel Level);
}
