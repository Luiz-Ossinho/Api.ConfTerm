﻿using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Requests
{
    public record RealizarLoginRequest(string Email, string Senha) : IPresentationRequest<LoginRequest>
    {
        public LoginRequest ToApplicationRequest()
            => new(new Email(Email), Senha);
    }
}
