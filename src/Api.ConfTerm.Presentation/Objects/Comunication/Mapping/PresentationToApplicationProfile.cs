using Api.ConfTerm.Application.Objects.Requests;
using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects.Comunication.Requests;
using AutoMapper;
using System;
using System.Linq;

namespace Api.ConfTerm.Presentation.Objects.Comunication.Mapping
{
    public class PresentationToApplicationProfile : Profile
    {
        public PresentationToApplicationProfile()
        {
            CreateMap<InsertHousingPresentationRequest, InsertHousingRequest>()
                .ForCtorParam("UserMail", opt => opt.MapFrom(pr => new Email(pr.UserEmail)));

            CreateMap<PerformLoginPresentationRequest, PerformLoginRequest>()
                .ForCtorParam("Email", opt => opt.MapFrom(pr => new Email(pr.Email)));

            CreateMap<InsertUserPresentationRequest, InsertUserRequest>()
                .ForCtorParam("Email", opt => opt.MapFrom(pr => new Email(pr.Email)))
                .ForCtorParam("Type", opt => opt.MapFrom(pr => UserType.GetValid(Enum.GetName(pr.Type))));

            CreateMap<InsertAnimalProductionPresentationRequest, InsertAnimalProductionRequest>()
                .ForCtorParam("BirthDay", opt => opt.MapFrom(pr => GetDateFromPresentationRequest(pr.BirthDay)))
                .ForCtorParam("MonitoringStart", opt => opt.MapFrom(pr => GetDateFromPresentationRequest(pr.MonitoringStart)))
                .ForCtorParam("MonitoringEnd", opt => opt.MapFrom(pr => GetDateFromPresentationRequest(pr.MonitoringEnd)));

            CreateMap<InsertMeasurementPresentationRequest, InsertMeasurementRequest>()
                .ForCtorParam("MeasurementDateTime", opt => opt.MapFrom(pr => GetDateTimeFromPresentationRequest(pr.Date, pr.Time)));

            CreateMap<InsertSpeciesPresentationRequest, InsertSpeciesRequest>();

            CreateMap<InsertTemperatureHumidityConfortPresentationRequest, InsertTemperatureHumidityConfortRequest>()
                .ForCtorParam("Level", opt => opt.MapFrom(pr => ConfortLevel.GetValid(Enum.GetName(pr.Level))));
            CreateMap<InsertBlackGlobeTemparuteHumidityIndexConfortPresentationRequest, InsertBlackGlobeTemparuteHumidityIndexConfortRequest>()
                .ForCtorParam("Level", opt => opt.MapFrom(pr => ConfortLevel.GetValid(Enum.GetName(pr.Level))));
            CreateMap<InsertTemperatureHumidityIndexConfortPresentationRequest, InsertTemperatureHumidityIndexConfortRequest>()
                .ForCtorParam("Level", opt => opt.MapFrom(pr => ConfortLevel.GetValid(Enum.GetName(pr.Level))));
        }

        public static DateTime GetDateFromPresentationRequest(string presentationDate)
        {
            var dateSplit = presentationDate.Split("/").Select(str => int.Parse(str)).ToArray();
            return new DateTime(dateSplit[2], dateSplit[1], dateSplit[0]);
        }

        public static DateTime GetDateTimeFromPresentationRequest(string presentationDate, string presentationTime)
        {
            var dateSplit = presentationDate.Split("/").Select(str => int.Parse(str)).ToArray();
            var timeSplit = presentationTime.Split(":").Select(str => int.Parse(str)).ToArray();
            return new DateTime(dateSplit[2], dateSplit[1], dateSplit[0], timeSplit[0], timeSplit[1], timeSplit[2]);
        }
    }
}
