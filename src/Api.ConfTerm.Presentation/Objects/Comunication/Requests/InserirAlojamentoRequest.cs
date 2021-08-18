using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;
using System;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record InserirAlojamentoRequest(string Indentificao, string Email) : IPresentationRequest<InsertHousingRequest>
    {
        public InsertHousingRequest ToApplicationRequest()
            => new(Indentificao, new Email(Email));
    }
}
