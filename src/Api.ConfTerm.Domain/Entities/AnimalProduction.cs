using Api.ConfTerm.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Api.ConfTerm.Domain.Entities
{
    public class AnimalProduction : IdentifiableEntity
    {
        public Housing Housing { get; set; }
        public Species Species { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime MonitoringStart { get; set; }
        public DateTime MonitoringEnd { get; set; }
        public string Equipament { get; set; }

        //EF Core Property 
        public virtual ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();

    }
}
