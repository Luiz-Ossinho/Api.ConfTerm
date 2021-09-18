using Api.ConfTerm.Application.Abstract;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertSpeciesRequest(string Name) : ApplicationRequest;
}
