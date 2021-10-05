using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Api.ConfTerm.Domain.Interfaces.Services
{
    public interface IEnviromentVariableReader
    {
        public string DatabaseUrl { get; }
        public string[] AllowedOrigins { get; }
        public string JwtSecret { get; }
        public Superuser Superuser { get; }
    }

    public record Superuser(string Username, string Password, string Email, string HousingIndentification, string AnimalProductionEquipament)
    {
        public User ToUser(IHashingService hashingSerivce)
        {
            var salt = hashingSerivce.GenerateSalt();
            var hash = hashingSerivce.GenerateHash(Password, salt);
            var user = new User
            {
                Name = Username,
                Salt = salt,
                Password = hash,
                Email = new Email(Email),
                Type = UserType.Administrator
            };

            var housing = new Housing
            {
                Identification = HousingIndentification,
                Owner = user
            };
            user.Housings.Add(housing);

            var now = DateTime.Now;
            var animalProduction = new AnimalProduction
            {
                Housing = housing,
                Birthday = now,
                Equipament = AnimalProductionEquipament,
                MonitoringEnd = now.AddYears(2),
                MonitoringStart = now
            };
            housing.AnimalProductions.Add(animalProduction);
            return user;
        }
    }
}
