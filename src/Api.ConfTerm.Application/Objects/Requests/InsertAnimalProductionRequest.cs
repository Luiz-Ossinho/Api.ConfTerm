using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ConfTerm.Application.Objects.Requests
{
    public record InsertAnimalProductionRequest(int HousingId, DateTime BirthDay, DateTime MonitoringStart, DateTime MonitoringEnd, string Equipament)
    {
    }
}
