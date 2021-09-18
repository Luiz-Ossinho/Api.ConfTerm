﻿using Api.ConfTerm.Application.Abstract;
using Api.ConfTerm.Domain.ValueObjects;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertHousingRequest(string Identificantion, Email UserMail) : ApplicationRequest;
}
