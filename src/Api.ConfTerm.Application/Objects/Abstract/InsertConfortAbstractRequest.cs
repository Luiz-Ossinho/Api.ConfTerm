using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Abstract
{
    public abstract record InsertConfortAbstractRequest(
        int SpeciesId,
        int MinimunAge,
        int MaximunAge,
        ConfortLevel Level
    ) : IApplicationRequest;
}
